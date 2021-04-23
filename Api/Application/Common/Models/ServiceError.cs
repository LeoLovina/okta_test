using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class ServiceError
    {
        public ServiceError(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }
        public int Code { get; }
        public string Message { get; }

        public static ServiceError DefaultError => new ServiceError(999,"An exception occured");
        
        public static ServiceError Error(string error) => new ServiceError(800, error);
    }
}
