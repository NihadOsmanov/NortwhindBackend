namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool succes, string message) : this(succes)
        {
            Succes = succes;
            Message = message;
        }
        public Result(bool succes)
        {
            Succes = succes;
        }

        public Result(string message)
        {
            Message = message;
        }

        public bool Succes { get; }
        public string Message { get; }
    }
}
