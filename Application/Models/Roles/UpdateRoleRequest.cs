using FluentValidation;
using Shared;

namespace Application.BLL.Models.Roles;

public class UpdateRoleRequest
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
}

public class UpdateRoleRequestValidator : AbstractValidator<UpdateRoleRequest>
{
    public UpdateRoleRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(ErrMessages.IdEmpty);

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(ErrMessages.RoleNameEmpty);
    }
}

