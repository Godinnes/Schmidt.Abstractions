using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Schmidt.Abstractions.FunctionMediator.Abstractions
{
    public interface ICommand : IRequest<IResponse>
    {
    }
}
