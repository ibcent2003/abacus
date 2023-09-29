using FluentValidation;
using Wbc.Application.Resources;

namespace Wbc.Application.Workflow.Commands.ExecuteApprovalCommand
{
    public class ExecuteApprovalCommandValidator : AbstractValidator<ExecuteApprovalCommand>
    {

        public ExecuteApprovalCommandValidator(CommonLocalizationService commonLocalization)
        {
            RuleFor(x => x.CommandName).NotEmpty().WithName(commonLocalization.Get("CommandNamelbl"));
            RuleFor(x => x.Comment).MaximumLength(400).WithName(commonLocalization.Get("Commentlbl"));
        }
    }
}
