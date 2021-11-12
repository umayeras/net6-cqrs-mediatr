using WebApp.Business.Constants;

namespace WebApp.Business.Responses
{
    public class ServiceResponse
    {
        public bool Success { get; init; }
        public string? Message { get; init; }
        public object? Payload { get; init; }

        //TODO: Metot isimleri CreateSuccessResponse olarak falan değiştirelibilir.

        public static ServiceResponse CreateSuccess(string? message)
        {
            return CreateServiceResponse(true, message, null);
        }

        public static ServiceResponse CreateSuccess(string? message, object? data)
        {
            return CreateServiceResponse(true, message, data);
        }

        public static ServiceResponse CreateExceptionError()
        {
            return CreateServiceResponse(false, ResponseMessage.ServerError, null);
        }

        public static ServiceResponse CreateError(string? message)
        {
            if (message == string.Empty)
            {
                message = ResponseMessage.ServerError;
            }

            return CreateServiceResponse(false, message, null);
        }

        private static ServiceResponse CreateServiceResponse(bool success, string? message, object? data)
        {
            return new ServiceResponse { Success = success, Message = message, Payload = data };
        }
    }
}