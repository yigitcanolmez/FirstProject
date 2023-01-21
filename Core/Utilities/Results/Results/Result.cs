namespace Core.Utilities.Results.Results
{
    public class Result : IResult
    {
        // get olanlar readonlydir fakat const içerisinde set edilebilir.
        public Result(bool success, string message) : this(success)
        {
            Message = message;
            IsSuccess = success;
        }
        public Result(bool success)
        {
            IsSuccess = success;
        }

        public bool IsSuccess { get; }
        public string Message { get; }
    }
}
