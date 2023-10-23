using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Schmidt.Abstractions.FunctionMediator.Implementations;
using Schmidt.Abstractions.Exception;

namespace Schmidt.Abstractions.FunctionMediator.Abstractions
{
    public abstract class AsyncCommandHandler<TRequest> : IRequestHandler<TRequest, IResponse>
      where TRequest : ICommand
    {
        public async Task<IResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = new Response();
                response.ObjectResult = await HandlerAsync(request);
                if (response.ObjectResult == null)
                    response.Status = System.Net.HttpStatusCode.NoContent;
                response.Status = System.Net.HttpStatusCode.OK;
                return response;
            }
            catch(CustomException customExeption)
            {
                var response = new Response();
                response.Status = customExeption.HttpStatusCode;
                response.Message = customExeption.Message;
                return response;
            }
            catch (System.Exception ex)
            {
                var response = new Response();
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                return response;
            }
        }
        public abstract Task<object> HandlerAsync(TRequest request);
    }

    public abstract class CommandHandler<TRequest> : IRequestHandler<TRequest, IResponse>
      where TRequest : ICommand
    {
        public async Task<IResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = new Response();
                response.ObjectResult = Handler(request);
                if (response.ObjectResult == null)
                    response.Status = System.Net.HttpStatusCode.NoContent;
                response.Status = System.Net.HttpStatusCode.OK;
                return response;
            }
            catch (CustomException customExeption)
            {
                var response = new Response();
                response.Status = customExeption.HttpStatusCode;
                response.Message = customExeption.Message;
                return response;
            }
            catch (System.Exception ex)
            {
                var response = new Response();
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                return response;
            }
        }
        public abstract object Handler(TRequest request);
    }
}
