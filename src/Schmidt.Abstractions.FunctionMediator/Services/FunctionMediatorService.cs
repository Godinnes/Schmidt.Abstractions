using MediatR;
using Microsoft.AspNetCore.Http;
using Schmidt.Abstractions.FunctionMediator.Abstractions;
using Schmidt.Abstractions.FunctionMediator.Helpers;
using System.Threading.Tasks;

namespace Schmidt.Abstractions.FunctionMediator.Services
{
    internal class FunctionMediatorService : IFunctionMediatorService
    {
        private readonly IMediator _mediatorR;

        public FunctionMediatorService(IMediator mediatorR)
        {
            _mediatorR = mediatorR;
        }

        public async Task<IResponse> SendAsync<TCommand>(HttpRequest request)
           where TCommand : ICommand, new()
        {
            var commmand = request.ToCommand<TCommand>();
            return await _mediatorR.Send(commmand);
        }
    }
}
