using System.Collections.Generic;
using Wbc.Application.Common.Enums;

namespace Wbc.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string GetUserId();
        int GetUserOrganisationId();
        string GetUserClaim(Application.Common.Enums.ClaimTypes claimTypes);
        string GetUserName(string userId);
        bool UserIsInRole(string role);
        IList<string> GetCurrentUserRoles();
        bool UserHasRole(Roles role);

    }
}
