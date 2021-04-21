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
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }

        public static ServiceResult<T> Success<T>(T data)
        {
            return new ServiceResult<T>(data);
        }
    }
}
