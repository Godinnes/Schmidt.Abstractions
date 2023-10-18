using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Schmidt.Abstractions.Mediator.Abstractions
{
    public abstract class AsyncCommandHandler<TRequest> : IRequestHandler<TRequest>
       where TRequest : ICommand
    {
        public Task Handle(TRequest request, CancellationToken cancellationToken)
        {
            return HandlerAsync(request);
        }
        public abstract Task HandlerAsync(TRequest request);
    }
    public abstract class AsyncCommandHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
        where TRequest : ICommand<TResult>
    {
        public Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            return HandlerAsync(request);
        }
        public abstract Task<TResult> HandlerAsync(TRequest request);
    }
    public abstract class CommandHandler<TRequest> : IRequestHandler<TRequest>
           where TRequest : ICommand
    {
        public Task Handle(TRequest request, CancellationToken cancellationToken)
        {
            Handler(request);
            return Task.CompletedTask;
        }
        public abstract void Handler(TRequest request);
    }
    public abstract class CommandHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
           where TRequest : ICommand<TResult>
    {
        public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var result = Handler(request);
            return await Task.FromResult(result);
        }
        public abstract TResult Handler(TRequest request);
    }
}
