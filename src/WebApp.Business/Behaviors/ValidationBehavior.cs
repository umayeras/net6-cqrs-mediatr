using FluentValidation;
using FluentValidation.Results;
using MediatR;
using WebApp.Business.Models;
using WebApp.Business.Responses;

namespace WebApp.Business.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ServiceResponse, new()
{
    private readonly IEnumerable<IValidator<TRequest>> validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        this.validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (!validators.Any())
        {
            return await next.Invoke();
        }

        var context = new ValidationContext<TRequest>(request);
        var results = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = results.SelectMany(r => r.Errors).Where(f => f != null).ToList();

        if (!failures.Any())
        {
            return await next.Invoke();
        }

        var response = CreateValidationErrorResponse(failures);

        return await Task.FromResult(response as TResponse);
    }

    private ValidationErrorResponse CreateValidationErrorResponse(IEnumerable<ValidationFailure> failures)
    {
        var errors = failures.Select(failure => new ValidationError(failure.PropertyName, failure.ErrorMessage)).ToList();

        return ValidationErrorResponse.Create(errors);
    }
}