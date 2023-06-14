namespace Web.Models
{
    public class ErrorCodeModel
    {
        public int? StatusCode { get; set; }
        public string? Message { get; set; }

        public ErrorCodeModel(int? statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
