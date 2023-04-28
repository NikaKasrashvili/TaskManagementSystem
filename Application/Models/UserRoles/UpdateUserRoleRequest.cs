using FluentValidation;
using Shared;

namespace Application.BLL.Models.UserRoles;

public class UpdateUserRoleRequest
{
    public string RoleId { get; set; } = null!;
    public string UserId { get; set; } = null!;
}

#region validator

public class UpdateUserRoleRequestValidator : AbstractValidator<UpdateUserRoleRequest>
{
    public UpdateUserRoleRequestValidator()
    {
        RuleFor(x => x.RoleId)
            .NotEmpty()
            .WithMessage(ErrMessages.RoleIdEmpty);

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(ErrMessages.RoleIdEmpty);
    }

}

#endregion