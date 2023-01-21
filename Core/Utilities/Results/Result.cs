using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // get olanlar readonlydir fakat const içerisinde set edilebilir.
        public Result(bool success, string message)
        {
            Message = message;
            IsSuccess = success;
        }
        public Result(bool success )
        {
             IsSuccess = success;
        }

        public bool IsSuccess { get; }
        public string Message { get; }
    }
}
