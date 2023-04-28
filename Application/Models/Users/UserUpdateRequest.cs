using Shared;

namespace Application.BLL.Models.Users;

public class UserUpdateRequest
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}

public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
{
    public UserUpdateRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(ErrMessages.IdEmpty);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage(ErrMessages.FirstNameEmpty);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage(ErrMessages.LastNameNameEmpty);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage(ErrMessages.PhoneNumberEmpty);
    }
}
