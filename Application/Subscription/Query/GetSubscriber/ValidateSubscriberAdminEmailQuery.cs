using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;

namespace Wbc.Application.Subscription.Query.GetSubscriber
{
    public class ValidateSubscriberAdminEmailQuery : IRequest<bool>
    {
        public string EmailAddress { get; set; }

    }

    public class ValidateSubscriberAdminEmailQueryHandler : IRequestHandler<ValidateSubscriberAdminEmailQuery, bool>
    {

        private readonly ISsoService _ssoService;
        public ValidateSubscriberAdminEmailQueryHandler(ISsoService ssoService)
        {
            _ssoService = ssoService;
        }

        public async Task<bool> Handle(ValidateSubscriberAdminEmailQuery request, CancellationToken cancellationToken)
        {
            var users = await _ssoService.GetUsersAsync(new ApiSearchModel { SearchText = request.EmailAddress, Page = 1, PageSize = 10 }, cancellationToken);

            return users.Users.ToList().Any();
        }
    }
}
