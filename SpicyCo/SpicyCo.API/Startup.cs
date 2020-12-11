using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SpicyCo.DataAccessLayer.Data;
using MediatR;
using System.Reflection;
using SpicyCo.DataAccessLayer.Handlers;
using SpicyCo.DataAccessLayer.UnitOfWork;
using SpicyCo.BusinessLayer.Interfaces;
using SpicyCo.BusinessLayer.Managers;

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