namespace Application.Common.Models
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
        public bool Succeeded => Errors==null ? true : false;
        public ServiceError Errors { get; set; }

        public static ServiceResult<T> Success<T>(T data)
        {
            return new ServiceResult<T>(data);
        }

        public static ServiceResult Failed()
        {
            var result = new ServiceResult {Errors = ServiceError.DefaultError};
            return result;
        }

        public static ServiceResult Failed(string error)
        {
            var result = new ServiceResult {Errors = ServiceError.Error(error)};
            return result;
        }
    }
}
