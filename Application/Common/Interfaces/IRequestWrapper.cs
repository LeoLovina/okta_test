using Application.Common.Models;
using MediatR;

namespace Application.Common.Interfaces
{
    public interface IRequestWrapper<T>: IRequest<ServiceResult<T>>
    {
    }
}
