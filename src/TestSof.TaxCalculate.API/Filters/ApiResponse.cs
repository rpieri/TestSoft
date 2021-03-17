namespace TestSof.TaxCalculate.API.Filters
{
    public class ApiResponse
    {
        public ApiResponse(string message, object data)
        {
            Message = message;
            Data = data;
        }

        public string Message { get; }
        public object Data { get; }
    }
}