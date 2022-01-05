using WebApp.Business.Constants;
using WebApp.Business.Models;

namespace WebApp.Business.Responses;

public class ValidationErrorResponse : ServiceResponse
{
    public List<ValidationError> Errors { get; set; }

    public ValidationErrorResponse(List<ValidationError> errors)
    {
        Success = false;
        Message = ResponseMessage.InvalidRequest;
        Errors = errors;
    }

    public static ValidationErrorResponse Create(List<ValidationError> errors)
    {
        return new ValidationErrorResponse(errors);
    }
}