using MediatR;

namespace Schmidt.Abstractions.Mediator.Abstractions
{
    public interface ICommand : IRequest
    {
    }
    public interface ICommand<out TResult> : IRequest<TResult>
    {

    }
}
