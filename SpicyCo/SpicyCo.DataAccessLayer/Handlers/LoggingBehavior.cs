using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpicyCo.DataAccessLayer.Handlers
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        //private readonly ILogger _logger;
        //public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        //{
        //    _logger = logger;
        //}
        public async Task<TResponse> Handle(TRequest request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResponse> next)
        {
            //_logger.LogDebug("Generic call");
            var response = await next();
            //_logger.LogDebug("Generic call has been done");
            return response;
        }
    }
}
