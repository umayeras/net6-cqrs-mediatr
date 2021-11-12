namespace WebApp.Business.Models
{
    public class ExceptionError
    {
        public string MethodName { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }

        public ExceptionError(string? methodName, string message, string? innerException, string? stackTrace)
        {
            MethodName = methodName ?? string.Empty;
            Message = message ?? string.Empty;
            InnerException = innerException ?? string.Empty;
            StackTrace = stackTrace ?? string.Empty;
        }
    }
}