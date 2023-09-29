using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;
using Permission = Wbc.Application.Common.Enums.Permission;
using Wbc.Application.Resources;

namespace Wbc.Application.Registration.Command.AddRegister
{
   public class AddRegisterCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class AddRegisterCommandHandler : IRequestHandler<AddRegisterCommand, int>
    {

        private readonly AdminConfiguration _adminConfiguration;
        private readonly CommonLocalizationService _commonLocalization;
        private readonly IApplicationDbContext _context;
        private readonly ISsoService _ssoService;

        public AddRegisterCommandHandler(AdminConfiguration adminConfiguration, CommonLocalizationService commonLocalization, IApplicationDbContext context, ISsoService ssoService)
        {
            _context = context;
            _adminConfiguration = adminConfiguration;
            _ssoService = ssoService;
            _commonLocalization = commonLocalization;
        }
        public async Task<int> Handle(AddRegisterCommand request, CancellationToken cancellationToken)
        {
            var toolUserRole = await _ssoService.GetRolesAsync(new ApiSearchModel
            {
                Page = 1,
                PageSize = 10,
                SearchText = Roles.eTradeToolUser.GetAttributeStringValue()

            }, cancellationToken);

            var abacusUserRole = await _ssoService.GetRolesAsync(new ApiSearchModel
            {
                Page = 1,
                PageSize = 10,
                SearchText = Roles.abacusUser.GetAttributeStringValue()

            }, cancellationToken);

            var roles = toolUserRole.Roles.ToList();
            var abRoles = abacusUserRole.Roles.ToList();

            if (!roles.Any()) throw new ValidationException(_commonLocalization.Get("GetRoleFailedError"));
            if (!abRoles.Any()) throw new ValidationException(_commonLocalization.Get("GetRoleFailedError"));

            var eTradeRole = roles.First();
            var abacusRole = abRoles.First();


            //Create User if not Exist
            var createUserResult = await _ssoService.AddUserAsync(new User
            {
                Email = request.EmailAddress,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                LockOutEnabled = true,
                PhoneNumber = request.PhoneNumber,
                UserName = request.EmailAddress
            },
                cancellationToken);

            if (createUserResult == null) throw new ValidationException(_commonLocalization.Get("CreateUserFailedError"));

            //Set User Password
            var userPassword = await _ssoService.ChangePasswordAsync(new ChangePassword
            {
                UserId = createUserResult.Id,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword
            },
                cancellationToken);

            if (userPassword != HttpStatusCode.OK) throw new ValidationException(_commonLocalization.Get("ChangePasswordFailedError"));

            //Add User to eTrade Tool Role
            var addUserToRoleResult = await _ssoService.AddUserToRoleAsync(new UserRole
            {
                RoleId = eTradeRole.Id,
                UserId = createUserResult.Id

            }, cancellationToken);

            if (addUserToRoleResult != HttpStatusCode.OK) throw new ValidationException(_commonLocalization.Get("AddUserToRoleFailedError"));

            //Add User to eTrade Tool Role
            var addUserToAbRoleResult = await _ssoService.AddUserToRoleAsync(new UserRole
            {
                RoleId = abacusRole.Id,
                UserId = createUserResult.Id

            }, cancellationToken);

            if (addUserToAbRoleResult != HttpStatusCode.OK) throw new ValidationException(_commonLocalization.Get("AddUserToRoleFailedError"));

            var claimsList = new List<UserClaim>
                                 {
                                     new UserClaim
                                         {
                                             UserId = createUserResult.Id,
                                             ClaimValue = request.FirstName,
                                             ClaimType = Wbc.Application.Common.Enums.ClaimTypes.FirstName.GetAttributeStringValue()
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
                                 };


            if (!string.IsNullOrEmpty(request.MiddleName))
            {
                claimsList.Add(new UserClaim
                {
                    UserId = createUserResult.Id,
                    ClaimValue = request.MiddleName,
                    ClaimType = ClaimTypes.MiddleName.GetAttributeStringValue()
                });
            }

            //Add User to UserKey claim
            var addUserToclaimResult = await _ssoService.AddRangeClaimToUserAsync(new ClaimList
            {
                Claims = claimsList

            }, cancellationToken);

            if (addUserToclaimResult != HttpStatusCode.OK) throw new ValidationException(_commonLocalization.Get("AddUserToClaimFailedError"));

            return 1;
        }
    }
}
