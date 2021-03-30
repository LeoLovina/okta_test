using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Application.Common
{
    public class ServiceResult <T> : ServiceResult
    {
        public T Data { get; set; }

        public ServiceResult(T data)
        {
            Data = data;
        }
    }

    public class ServiceResult
    {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }

        public static ServiceResult<T> Success<T>(T data)
        {
            return new ServiceResult<T>(data);
        }
    }
}
