using System.Threading.Tasks;

namespace Schmidt.Abstractions.Mediator.Abstractions
{
    public interface IMediatorService
    {
        Task SendAsync(ICommand request);
        Task<TResult> SendAsync<TResult>(ICommand<TResult> request);
    }
}
