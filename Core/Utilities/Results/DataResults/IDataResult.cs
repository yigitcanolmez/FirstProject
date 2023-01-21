using Core.Utilities.Results.Results;

namespace Core.Utilities.Results.DataResult
{
    public interface IDataResult<T> : IResult
    {

        T Data { get; }
    }
}
