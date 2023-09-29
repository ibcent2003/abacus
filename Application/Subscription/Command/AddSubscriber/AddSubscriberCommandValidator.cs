using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;
using Wbc.Application.Resources;
// ReSharper disable StringLiteralTypo

namespace Wbc.Application.Subscription.Command.AddSubscriber
{
    public class AddSubscriberCommandValidator : AbstractValidator<AddSubscriberCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ISsoService _ssoService;

        public AddSubscriberCommandValidator(CommonLocalizationService commonLocalization, IApplicationDbContext dbContext, ISsoService ssoService)
        {
            _dbContext = dbContext;
            _ssoService = ssoService;
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithName(commonLocalization.Get("EmailAddresslbl"))
                .MaximumLength(256)
                .WithName(commonLocalization.Get("EmailAddresslbl"))
                .MustAsync(BeUniqueEmailAddress).WithMessage(commonLocalization.Get("BeUniqueEmailAddressError"));
            RuleFor(x => x.City).NotEmpty().WithName(commonLocalization.Get("Citylbl")).MaximumLength(75).WithName(commonLocalization.Get("Citylbl"));
            RuleFor(x => x.CountryCode).NotEmpty().WithName(commonLocalization.Get("CountryCodelbl")).MaximumLength(2).WithName(commonLocalization.Get("CountryCodelbl"));
            RuleFor(x => x.EntityName).NotEmpty().WithName(commonLocalization.Get("EntityNamelbl")).MaximumLength(120).WithName(commonLocalization.Get("EntityNamelbl"));
            RuleFor(x => x.FaxNumber).MaximumLength(15).WithName(commonLocalization.Get("FaxNumberlbl"));
            RuleFor(x => x.PhoneNumber).NotEmpty().WithName(commonLocalization.Get("PhoneNumberlbl")).MaximumLength(15).WithName(commonLocalization.Get("PhoneNumberlbl"));
            RuleFor(x => x.PostCode).NotEmpty().WithName(commonLocalization.Get("PostCodelbl")).MaximumLength(6).WithName(commonLocalization.Get("PostCodelbl"));
            RuleFor(x => x.StreetNumber).NotEmpty().WithName(commonLocalization.Get("StreetNumberlbl")).MaximumLength(200).WithName(commonLocalization.Get("StreetNamelbl"));
            RuleFor(x => x.Tin).NotEmpty().WithName(commonLocalization.Get("Tinlbl")).MaximumLength(15).WithName(commonLocalization.Get("Tinlbl"));
            //RuleFor(x => x.UserName).NotEmpty().WithName(commonLocalization.Get("UserNamelbl")).MaximumLength(256).WithName(commonLocalization.Get("UserNamelbl"));
            RuleFor(x => x.AdminPhoneNumber).NotEmpty().WithName(commonLocalization.Get("PhoneNumberlbl")).MaximumLength(15).WithName(commonLocalization.Get("PhoneNumberlbl"));
            RuleFor(x => x.AdminEmailAddress).NotEmpty().WithName(commonLocalization.Get("EmailAddresslbl"))
                .MaximumLength(250).WithName(commonLocalization.Get(commonLocalization.Get("EmailAddresslbl")))
                .MustAsync(BeUniqueUserAccount).WithMessage(commonLocalization.Get("BeUniqueUserAccountError"));
            RuleFor(x => x.FirstName).NotEmpty().WithName(commonLocalization.Get("FirstNamelbl")).MaximumLength(50).WithName(commonLocalization.Get("FirstNamelbl"));
            RuleFor(x => x.LastName).NotEmpty().WithName(commonLocalization.Get("LastNamelbl")).MaximumLength(50).WithName(commonLocalization.Get("LastNamelbl"));
            RuleFor(x => x.MiddleName).MaximumLength(50).WithName("MiddleNamelbl");
            RuleFor(x => x.Password).NotEmpty().WithName(commonLocalization.Get("Passwordlbl")).MaximumLength(50).WithName(commonLocalization.Get("Passwordlbl"));
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithName(commonLocalization.Get("ConfirmPasswordlbl")).MaximumLength(50).WithName(commonLocalization.Get("ConfirmPasswordlbl"))
                .Equal(x => x.Password).WithMessage(commonLocalization.Get("PasswordMismatchError"));


        }

        public async Task<bool> BeUniqueEmailAddress(string emailAddress, CancellationToken cancellationToken)
        {
            return await _dbContext.Subscribers
                .AllAsync(l => l.EmailAddress != emailAddress, cancellationToken: cancellationToken);
        }

        public async Task<bool> BeUniqueUserAccount(string username, CancellationToken cancellationToken)
        {
            var users = await _ssoService.GetUsersAsync(new ApiSearchModel { SearchText = username, Page = 1, PageSize = 10 }, cancellationToken);

            return !users.Users.ToList().Any();
        }
    }
}
