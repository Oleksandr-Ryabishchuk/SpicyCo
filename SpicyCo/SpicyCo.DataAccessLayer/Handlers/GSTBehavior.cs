using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpicyCo.DataAccessLayer.Handlers
{
    public class GSTBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, 
                                            CancellationToken cancellationToken, 
                                            RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();
            var costProp = response.GetType().GetProperties().Where(x => x.Name == "Cost")
                                   .FirstOrDefault();
            if(costProp != null)
            {
                var cost = (decimal)costProp.GetValue(response);
                cost *= 1.05m;
                costProp.SetValue(response, cost);
            }
            return response;
        }
    }
}
