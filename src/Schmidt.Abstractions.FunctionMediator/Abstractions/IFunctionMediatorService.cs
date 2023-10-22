using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Schmidt.Abstractions.FunctionMediator.Abstractions
{
    public interface IFunctionMediatorService
    {
        Task<IResponse> SendAsync<TCommand>(HttpRequest request)
            where TCommand : ICommand, new();
    }
}
