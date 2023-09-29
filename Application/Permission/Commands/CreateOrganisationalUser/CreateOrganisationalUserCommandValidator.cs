using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;
using Wbc.Application.Resources;

namespace Wbc.Application.Permission.Commands.CreateOrganisationalUser
{
    public class CreateOrganisationalUserCommandValidator : AbstractValidator<CreateOrganisationalUserCommand>
    {
        private readonly ISsoService _ssoService;


        public CreateOrganisationalUserCommandValidator(IApplicationDbContext dbContext, ISsoService ssoService, CommonLocalizationService commonLocalization)
        {
            _ssoService = ssoService;
            RuleFor(x => x.PhoneNumber).NotEmpty().WithName(commonLocalization.Get("PhoneNumberlbl")).MaximumLength(15).WithName(commonLocalization.Get("PhoneNumberlbl"));
            RuleFor(x => x.EmailAddress).NotEmpty().WithName(commonLocalization.Get("EmailAddresslbl"))
                .MaximumLength(250).WithName(commonLocalization.Get(commonLocalization.Get("EmailAddresslbl")))
                .MustAsync(BeUniqueUserAccount).WithMessage(commonLocalization.Get("BeUniqueUserAccountError"));
            RuleFor(x => x.FirstName).NotEmpty().WithName(commonLocalization.Get("FirstNamelbl")).MaximumLength(50).WithName(commonLocalization.Get("FirstNamelbl"));
            RuleFor(x => x.LastName).NotEmpty().WithName(commonLocalization.Get("LastNamelbl")).MaximumLength(50).WithName(commonLocalization.Get("LastNamelbl"));
            RuleFor(x => x.MiddleName).MaximumLength(50).WithName("MiddleNamelbl");

        }

        public async Task<bool> BeUniqueUserAccount(string username, CancellationToken cancellationToken)
        {
            var users = await _ssoService.GetUsersAsync(new ApiSearchModel { SearchText = username, Page = 1, PageSize = 10 }, cancellationToken);

            return !users.Users.ToList().Any();
        }
    }
}
