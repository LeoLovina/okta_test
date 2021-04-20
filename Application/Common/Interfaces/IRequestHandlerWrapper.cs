using Application.Common.Models;
using MediatR;

namespace Application.Common.Interfaces
{
    public interface IRequestHandlerWrapper<in TIn, TOut>: IRequestHandler<TIn, ServiceResult<TOut>> where TIn: IRequestWrapper<TOut>
    {
    }
}
