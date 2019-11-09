using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Bridge.Application.Common.Behaviors
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        // TODO: Re-implement current user service tracking after auth0 integration
        private readonly ILogger _logger;
        //private readonly ICurrentUserService _currentUserService;

        public RequestLogger(ILogger<TRequest> logger/*, ICurrentUserService currentUserService */)
        {
            _logger = logger;
            //_currentUserService = currentUserService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            // _logger.LogInformation("Northwind Request: {Name} {@UserId} {@Request}", 
            //     name, _currentUserService.UserId, request);

            _logger.LogInformation("Northwind Request: {Name} {@Request}", 
                name, request);

            return Task.CompletedTask;
        }
    }
}