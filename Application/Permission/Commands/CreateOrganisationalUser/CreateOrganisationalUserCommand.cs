using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;
using Wbc.Application.Resources;

namespace Wbc.Application.Permission.Commands.CreateOrganisationalUser
{
    public class CreateOrganisationalUserCommand : IRequest<Unit>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string OrganisationId { get; set; }
    }

    public class CreateOrganisationalUserCommandHandler : IRequestHandler<CreateOrganisationalUserCommand, Unit>
    {
        private readonly ISsoService _ssoService;
        private readonly CommonLocalizationService _commonLocalization;
        public CreateOrganisationalUserCommandHandler(ISsoService ssoService, CommonLocalizationService commonLocalization)
        {
            _ssoService = ssoService;
            _commonLocalization = commonLocalization;
        }

        public async Task<Unit> Handle(CreateOrganisationalUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _ssoService.GetRolesAsync(new ApiSearchModel
            {
                Page = 1,
                PageSize = 10,
                SearchText = Roles.CubeClientUser.GetAttributeStringValue()

            }, cancellationToken);

            var roles = result.Roles.ToList();

            if (!roles.Any()) throw new ValidationException(_commonLocalization.Get("GetRoleFailedError"));

            var role = roles.First();

            //Create User if not Exist
            var createUserResult = await _ssoService.AddUserAsync(new User
            {
                Email = request.EmailAddress,
                PhoneNumber = request.PhoneNumber,
                UserName = request.EmailAddress
            },
                cancellationToken);

            if (createUserResult == null) throw new ValidationException(_commonLocalization.Get("CreateUserFailedError"));

            //Add User to  Role
            var addUserToRoleResult = await _ssoService.AddUserToRoleAsync(new UserRole
            {
                RoleId = role.Id,
                UserId = createUserResult.Id
            },
                cancellationToken);

            if (addUserToRoleResult != HttpStatusCode.OK) throw new ValidationException(_commonLocalization.Get("AddUserToRoleFailedError"));

            var userInfo = await _ssoService.GetUserInfo(cancellationToken);
            var claimType = ClaimTypes.SubscriptionClaim.GetAttributeStringValue();
            var organisationId = userInfo.Claims.First(x => x.Type.Equals(claimType)).Value;

            //Add User to SubscriberKey claim
            var addUserToclaimResult = await _ssoService.AddRangeClaimToUserAsync(new ClaimList
            {
                Claims = new List<UserClaim>
                         {
                             new UserClaim
                                 {
                                     UserId = createUserResult.Id,
                                     ClaimValue = organisationId,
                                     ClaimType = claimType
                                 },
                             new UserClaim
                                 {
                                     UserId = createUserResult.Id,
                                     ClaimValue = request.FirstName,
                                     ClaimType = ClaimTypes.FirstName.GetAttributeStringValue()
                                 },
                             new UserClaim
                                 {
                                     UserId = createUserResult.Id,
                                     ClaimValue = request.MiddleName,
                                     ClaimType = ClaimTypes.MiddleName.GetAttributeStringValue()
                                 },
                             new UserClaim
                                 {
                                     UserId = createUserResult.Id,
                                     ClaimValue = request.LastName,
                                     ClaimType = ClaimTypes.LastName.GetAttributeStringValue()
                                 },
                             new UserClaim
                                 {
                                     UserId = createUserResult.Id,
                                     ClaimValue = request.PhoneNumber,
                                     ClaimType = System.Security.Claims.ClaimTypes.MobilePhone
                                 }
                         }
            },
                cancellationToken); ;


            if (addUserToclaimResult != HttpStatusCode.OK) throw new ValidationException(_commonLocalization.Get("AddUserToClaimFailedError"));

            return Unit.Value;

        }
    }
}
