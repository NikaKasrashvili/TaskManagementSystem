using FluentValidation;
using Shared;

namespace Application.BLL.Models.Tasks;

public class CreateTaskRequest
{
    public string? Title { get; init; }
    public string? SmallDescription { get; init; }
    public string? Description { get; init; }
    /// <summary>
    /// Path of uploaded file or image
    /// </summary>
    public string? FilePath { get; init; }
    /// <summary>
    /// User which is responsible to make current task.
    /// </summary>
    public string UserId { get; init; } = null!;
}

#region Validator
public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>
{
    public CreateTaskRequestValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(248)
            .WithMessage(ErrMessages.TitleMaxLength);

        RuleFor(x => x.SmallDescription)
            .MaximumLength(248)
            .WithMessage(ErrMessages.SmallDescrMaxLength);

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(ErrMessages.UserIdEmpty);
    }

}
#endregion



