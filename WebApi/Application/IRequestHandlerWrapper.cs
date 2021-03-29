using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebApi.MediatTest;

namespace WebApi.Application
{
    public interface IRequestHandlerWrapper<in TIn, TOut>: IRequestHandler<TIn, TOut> where TIn: IRequest<TOut>
    {
    }
}
