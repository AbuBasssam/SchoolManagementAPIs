using ApplicationLayer.Validations;
using FluentValidation;

namespace SchoolApp.Application.Features.AuthenticationFeatrue.Queries.AuthorizeUser;

public class AuthorizeUserQueryValidator : AbstractValidator<AuthorizeUserQuery>
{

    public AuthorizeUserQueryValidator() => ApplyValidationrules();

    public void ApplyValidationrules() => RuleFor(x => x.AccessToken).ApplyNotEmptyRule().ApplyNotNullableRule();
}
