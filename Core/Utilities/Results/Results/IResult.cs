namespace Core.Utilities.Results.Results
{
    //Voidler için başlangıç
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }

    }
}
