using ApplicationCore.Candidates.Commands;
using FluentValidation;

namespace ApplicationCore;

public class UpsertCandidateValidator : AbstractValidator<UpsertCandidateCmd>
{
    public UpsertCandidateValidator()
    {
        RuleFor(c => c.model.Email).NotEmpty().WithMessage("Email cannot be empty");
        RuleFor(c => c.model.FirstName).NotEmpty().WithMessage("First name cannot be empty");
        RuleFor(c => c.model.LastName).NotEmpty().WithMessage("Last name cannot be empty");
        RuleFor(c => c.model.Comment).NotEmpty().WithMessage("Comment cannot be empty");
    }
}
