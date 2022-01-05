using FluentValidation;
using WebApp.Business.Constants;
using WebApp.Business.Queries;

namespace WebApp.Business.Validators;

public class GetSampleByIdQueryValidator : AbstractValidator<GetSampleByIdQuery>
{
    public GetSampleByIdQueryValidator()
    {
        RuleFor(request => request.Id)
            .GreaterThanOrEqualTo(1)
            .WithMessage(ValidationMessage.InvalidId);
    }
}