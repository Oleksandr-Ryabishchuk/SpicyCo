using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SpicyCo.DataAccessLayer.Data;
using MediatR;
using System.Reflection;
using SpicyCo.DataAccessLayer.Handlers;
using SpicyCo.DataAccessLayer.UnitOfWork;
using SpicyCo.BusinessLayer.Interfaces;
using SpicyCo.BusinessLayer.Managers;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using SpicyCo.DataAccessLayer.Entities;

namespace SpicyCo.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(GSTBehavior<,>));

            services.AddTransient<IRequestHandler<AddPremiumAccountRequest, AddPremiumAccountResponse>,
                AddPremiumAccountHandler>();
              

            services.AddDbContext<DataContext>(options => options.UseSqlServer
            (Configuration.GetConnectionString("DefaultConnection"), 
            x => x.MigrationsAssembly("SpicyCo.DataAccessLayer")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IProductManager, ProductManager>();

            IdentityBuilder builder = services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<DataContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                options.AddPolicy("ModeratePhotoRole", policy => policy.RequireRole("Admin", "Moderator"));
                options.AddPolicy("VipOnly", policy => policy.RequireRole("VIP"));
            });

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpicyCo.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpicyCo.API v1"));
            }
            
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            
            app.UseHttpsRedirection();

            app.UseRouting();            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
