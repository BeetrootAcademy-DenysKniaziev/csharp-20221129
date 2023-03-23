using System.Collections.Generic;

namespace Lesson36.Bll.Utils
{
    public class OperationResult<T>
    {
        public OperationResult(bool success, T data, IDictionary<string, string[]> validationErrors = null)
        {
            Success = success;
            Data = data;
            ValidationErrors = validationErrors;
        }

        public bool Success { get; set; }

        public T Data { get; set; }

        public IDictionary<string, string[]> ValidationErrors { get; }
    }
}
