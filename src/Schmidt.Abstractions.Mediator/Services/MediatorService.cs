using MediatR;
using Schmidt.Abstractions.Mediator.Abstractions;
using System.Threading.Tasks;

namespace Schmidt.Abstractions.Mediator.Services
{
    internal class MediatorService : IMediatorService
    {
        private readonly IMediator _mediatorR;
        public MediatorService(IMediator mediatorR)
        {
            _mediatorR = mediatorR;
        }

        public Task SendAsync(ICommand request)
        {
            return _mediatorR.Send(request);
        }

        public Task<TResult> SendAsync<TResult>(ICommand<TResult> request)
        {
            return _mediatorR.Send(request);
        }
    }
}
