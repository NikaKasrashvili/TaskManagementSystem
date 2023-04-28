using Shared;

namespace Application.BLL.Models.Auth;
public class RegistrationRequest
{
    public string Email { get; init; } = null!;
    public string UserName { get; init; } = null!;
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public string? RoleId { get; init; }
}

#region Validation

public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
{
    public RegistrationRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(ErrMessages.EmailEmpty)
            .EmailAddress();

        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage(ErrMessages.UsernameEmpty);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage(ErrMessages.FirstNameEmpty)
            .MaximumLength(48)
            .WithMessage(ErrMessages.FirstNameMaxChar);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage(ErrMessages.LastNameNameEmpty)
            .MaximumLength(48)
            .WithMessage(ErrMessages.LastNameMaxChar);

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(ErrMessages.PasswordEmpty)
            .MinimumLength(6)
            .WithMessage(ErrMessages.PasswordMinChar);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage(ErrMessages.PhoneNumberEmpty)
            .MaximumLength(48)
            .WithMessage(ErrMessages.PhoneNumberMaxChar);
    }
}
#endregion

