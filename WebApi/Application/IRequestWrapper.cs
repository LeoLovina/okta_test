using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebApi.Application.Common;

namespace WebApi.Application
{
    public interface IRequestWrapper<T>: IRequest<ServiceResult<T>>
    {
    }
}
