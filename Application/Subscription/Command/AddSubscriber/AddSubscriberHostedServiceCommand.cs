using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;
using Wbc.Application.Resources;
using Wbc.Domain.Entities;

namespace Wbc.Application.Subscription.Command.AddSubscriber
{
    public class AddSubscriberHostedServiceCommand : IRequest<Unit>
    {
        public string JsonString { get; set; }
    }

    public class AddSubscriberHostedServiceCommandHandler : IRequestHandler<AddSubscriberHostedServiceCommand, Unit>
    {
        private readonly AdminConfiguration _adminConfiguration;
        private readonly CommonLocalizationService _commonLocalization;
        private readonly IApplicationDbContext _context;
        private readonly ISsoService _ssoService;
        private readonly ISubscriptionService _subscriptionService;
        public AddSubscriberHostedServiceCommandHandler(AdminConfiguration adminConfiguration, CommonLocalizationService commonLocalization, IApplicationDbContext context, ISsoService ssoService, ISubscriptionService subscriptionService)
        {
            _adminConfiguration = adminConfiguration;
            _commonLocalization = commonLocalization;
            _context = context;
            _ssoService = ssoService;
            _subscriptionService = subscriptionService;
        }

        public async Task<Unit> Handle(AddSubscriberHostedServiceCommand command, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var request = JsonConvert.DeserializeObject<AddSubscriberCommand>(command.JsonString);

                var result = await _ssoService.GetRolesAsync(new ApiSearchModel
                {
                    Page = 1,
                    PageSize = 10,
                    SearchText = Roles.CubeClientAdmin.GetAttributeStringValue()

                }, cancellationToken);

                var roles = result.Roles.ToList();

                if (!roles.Any()) throw new ValidationException(_commonLocalization.Get("GetRoleFailedError"));

                var role = roles.First();

                //Create User if not Exist
                var createUserResult = await _ssoService.AddUserAsync(new User
                {
                    Email = request.AdminEmailAddress,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    LockOutEnabled = true,
                    PhoneNumber = request.AdminPhoneNumber,
                    UserName = request.AdminEmailAddress
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

                //Add User to Cube Admin Role
                var addUserToRoleResult = await _ssoService.AddUserToRoleAsync(new UserRole
                {
                    RoleId = role.Id,
                    UserId = createUserResult.Id
                },
                    cancellationToken);

                if (addUserToRoleResult != HttpStatusCode.OK) throw new ValidationException(_commonLocalization.Get("AddUserToRoleFailedError"));


                //Create Subscriber
                var addSubscriberResult = await _subscriptionService.SubscribeAsync(new Common.Models.Subscriber
                {
                    Tin = request.Tin,
                    EntityName = request.EntityName,
                    StreetNumber = request.StreetNumber,
                    PostCode = request.PostCode,
                    City = request.City,
                    CountryCode = request.CountryCode,
                    EmailAddress = request.EmailAddress,
                    FaxNumber = request.FaxNumber,
                    PhoneNumber = request.PhoneNumber
                },
                    cancellationToken);


                //Add User to SubscriberKey claim
                var addUserToclaimResult = await _ssoService.AddRangeClaimToUserAsync(new ClaimList
                {
                    Claims = new List<UserClaim>
               {
                   new UserClaim
                       {
                           UserId = createUserResult.Id,
                           ClaimValue = addSubscriberResult.Id.ToString(),
                           ClaimType = ClaimTypes.SubscriptionClaim.GetAttributeStringValue()
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
                    cancellationToken);


                if (addUserToclaimResult != HttpStatusCode.OK) throw new ValidationException(_commonLocalization.Get("AddUserToClaimFailedError"));

                //Save Documents Locally
                var submittedDocuments = request.DocumentsUploaded.Select(x => new ProcessSubmittedDocument
                {
                    DocumentOwnerId = addSubscriberResult.Id,
                    ProcessRequiredDocumentId = x.RequiredDocumentId,
                    DocumentUrl = x.UniqueFileName,
                    DocumentExtension = x.ContentType,
                    DocumentName = x.FileName

                }).ToList();

                _context.ProcessSubmittedDocuments.AddRange(submittedDocuments);

                var process = EnumHelper.GetEnumFromString<Common.Enums.Process>(request.ProcessCode);

                var entityType = process.GetEntityType();

                //Save Subscriber Locally
                var subscriper = new Domain.Entities.Subscriber
                {
                    City = request.City,
                    CountryCode = request.CountryCode,
                    ProcessName = process.GetAttributeDescription(),
                    DocumentSource = entityType.GetAttributeDescription(),
                    EntityTypeCode = entityType.GetAttributeStringValue(),
                    EmailAddress = request.EmailAddress,
                    EntityName = request.EntityName,
                    FaxNumber = request.FaxNumber,
                    PhoneNumber = request.PhoneNumber,
                    PostCode = request.PostCode,
                    StreetNumber = request.StreetNumber,
                    Tin = request.Tin,
                    ParentId = addSubscriberResult.Id,
                    WorkflowSchemeCode = process.GetWorkflowScheme(_adminConfiguration),
                    UserSubscriptions = new List<UserSubscription>
                                        {
                                            new UserSubscription
                                                {
                                                    UserId = createUserResult.Id,
                                                    UserName = createUserResult.UserName,
                                                    FirstName = request.FirstName,
                                                    MiddleName= request.MiddleName,
                                                    LastName = request.LastName,
                                                    EmailAddress= request.AdminEmailAddress,
                                                    PhoneNumber = request.AdminPhoneNumber
                                                }
                                        }
                };

                _context.Subscribers.Add(subscriper);

                //Assign User Permissions
                var availablePermissions = await _context.Permissions.Where(x => x.IsActive && !x.RequireAdminRole).Select(x => x.Id).ToListAsync(cancellationToken);

                _context.UserPermissions.AddRange(availablePermissions.Select(x => new UserPermission
                {
                    UserId = createUserResult.Id,
                    PermissionId = x
                }));
                await _context.SaveChangesAsync(cancellationToken);


            }

            return Unit.Value;
        }
    }
}
