namespace ScrapingAppDefinitions.ResultType
{
    public abstract class Result
    {
        public bool IsSuccess { get; protected set; }
    }

    public class ResultSuccess : Result
    {
        public ResultSuccess()
        {
            this.IsSuccess = true;
        }
    }

    public class ResultError : Result
    {
        public ResultError(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.IsSuccess = false;
        }

        public string ErrorMessage { get; } = "";
    }


    public class Result<T> : Result
    {
        public T? Value { get; }

        public Result(T data) {
            this.Value = data;
            this.IsSuccess = true;
            
        }

        public Result(string ErrorMessage)
        {
            this.IsSuccess=false;
            this.ErrorMessage = ErrorMessage;
        }


        public string ErrorMessage { get; } = "";
    }
}