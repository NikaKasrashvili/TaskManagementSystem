using FluentValidation;
using Shared;

namespace Application.BLL.Models.Roles;

public class CreateRoleRequest
{
    public string Name { get; set; } = null!;
}

public class CreateRoleRequestValidator : AbstractValidator<CreateRoleRequest>
{
    public CreateRoleRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ErrMessages.Empty);
    }
}


