using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using WebApp.Business.Models;
using WebApp.Business.Responses;

namespace WebApp.Business.Behaviors;

public class ExceptionHandlingBehavior<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
    where TRequest : notnull
    where TException : Exception
    where TResponse : notnull, ServiceResponse
{
    private readonly ILogger<ExceptionHandlingBehavior<TRequest, TResponse, TException>> logger;

    public ExceptionHandlingBehavior(
        ILogger<ExceptionHandlingBehavior<TRequest, TResponse, TException>> logger)
    {
        this.logger = logger;
    }

    public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
    {
        var error = CreateExceptionError(exception);

        logger.LogError(JsonSerializer.Serialize(error));

        var response = ServiceResponse.CreateExceptionError();

        state.SetHandled(response as TResponse);

        return Task.FromResult(response);
    }

    private static ExceptionError CreateExceptionError(TException exception)
    {
        var methodName = exception.TargetSite?.DeclaringType?.DeclaringType?.FullName;
        var message = exception.Message;
        var innerException = exception.InnerException?.Message;
        var stackTrace = exception.StackTrace;

        return new ExceptionError(methodName, message, innerException, stackTrace);
    }
}