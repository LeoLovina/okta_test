using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebApi.Application.Common;


namespace WebApi.Application
{
    public interface IRequestHandlerWrapper<in TIn, TOut>: IRequestHandler<TIn, ServiceResult<TOut>> where TIn: IRequestWrapper<TOut>
    {
    }
}
