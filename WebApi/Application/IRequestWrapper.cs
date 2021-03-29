using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace WebApi.Application
{
    public interface IRequestWrapper<out T>: IRequest<T>
    {
    }
}
