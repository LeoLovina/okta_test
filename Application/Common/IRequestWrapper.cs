using MediatR;

namespace Application.Common
{
    public interface IRequestWrapper<T>: IRequest<ServiceResult<T>>
    {
    }
}
