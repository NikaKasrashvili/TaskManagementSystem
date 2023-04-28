using FluentValidation;
using Shared;

namespace Application.BLL.Models.Roles;

public class AssingnClaimRequest
{
    public string Claim { get; set; }
    public string RoleId { get; set; }
}
public class AssignClaimValidator : AbstractValidator<AssingnClaimRequest>
{
    public AssignClaimValidator()
    {
        RuleFor(x => x.Claim).NotEmpty().WithMessage(ErrMessages.ClaimEmpty);
        RuleFor(x => x.Claim).Matches(@"^\w{0,}_(Create|Delete|Read)*$").WithMessage(ErrMessages.ClaimInvalidPattern);
        RuleFor(x => x.RoleId).NotEmpty().WithMessage(ErrMessages.RoleIdEmpty);
    }
}



