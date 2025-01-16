using FluentValidation;
using SmartPOS.Core.Features.Branches.Commands.Models;

namespace SmartPOS.Core.Features.Branches.Commands.Validators;

public class AddBranchCommandValidator : AbstractValidator<AddBranchCommandModel>
{
    public AddBranchCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name Is Requrired");

    }
}
