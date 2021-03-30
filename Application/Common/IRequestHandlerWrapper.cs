using MediatR;

namespace Application.Common
{
    public interface IRequestHandlerWrapper<in TIn, TOut>: IRequestHandler<TIn, ServiceResult<TOut>> where TIn: IRequestWrapper<TOut>
    {
    }
}
