using Core.Utilities.Results.Results;

namespace Core.Utilities.Results.DataResult
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
            Message = message;
            IsSuccess = success;
        }   
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
            IsSuccess = success;
        }
        public T Data { get; }
        public bool IsSuccess { get; }
        public string Message { get; }


    }
}
