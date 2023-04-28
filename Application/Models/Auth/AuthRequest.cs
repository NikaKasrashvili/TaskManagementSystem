using Shared;

namespace Application.BLL.Models.Auth;

public class AuthRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}

#region Validator

public class AuthRequestValidator : AbstractValidator<AuthRequest>
{
    public AuthRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(ErrMessages.EmailEmpty);

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(ErrMessages.PasswordEmpty)
            .MinimumLength(6)
            .WithMessage(ErrMessages.PasswordMinChar);

    }
}

#endregion

