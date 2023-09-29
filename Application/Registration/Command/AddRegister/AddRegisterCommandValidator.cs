using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;
using Wbc.Application.Resources;

namespace Wbc.Application.Registration.Command.AddRegister
{
    public class AddRegisterCommandValidator: AbstractValidator<AddRegisterCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ISsoService _ssoService;

        public AddRegisterCommandValidator(CommonLocalizationService commonLocalization, IApplicationDbContext dbContext, ISsoService ssoService)
        {
            _dbContext = dbContext;
            _ssoService = ssoService;
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithName(commonLocalization.Get("EmailAddresslbl"))
                .MaximumLength(256)
                .WithName(commonLocalization.Get("EmailAddresslbl"))
                .MustAsync(BeUniqueEmailAddress).WithMessage(commonLocalization.Get("BeUniqueEmailAddressError"));
            RuleFor(x => x.PhoneNumber).NotEmpty().WithName(commonLocalization.Get("PhoneNumberlbl")).MaximumLength(15).WithName(commonLocalization.Get("PhoneNumberlbl"));
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
