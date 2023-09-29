using System.Net;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Models;

namespace Wbc.Application.Common.Interfaces
{
    public interface ISsoService
    {
        Task<User> AddUserAsync(User user, CancellationToken cancellation);
        Task<HttpStatusCode> AddUserToRoleAsync(UserRole userRole, CancellationToken cancellationToken);
        Task<HttpStatusCode> ChangePasswordAsync(ChangePassword changePassword, CancellationToken cancellationToken);
        Task<HttpStatusCode> AddClaimToUserAsync(UserClaim userClaim, CancellationToken cancellationToken);
        Task<HttpStatusCode> AddRangeClaimToUserAsync(ClaimList userClaims, CancellationToken cancellationToken);
        Task<UserQueryListResult> GetUsersAsync(ApiSearchModel searchModel, CancellationToken cancellationToken);
        Task<RoleQueryListResult> GetRolesAsync(ApiSearchModel searchModel, CancellationToken cancellationToken);
        Task<UserQueryListResult> GetUsersByClaimAsync(ApiSearchModel searchModel, CancellationToken cancellationToken);
        Task<UserInfoResponse> GetUserInfo(CancellationToken cancellationToken);
        Task<string> GetUserClaimValue(ClaimTypes claimType, CancellationToken cancellationToken);
        Task<ClaimList> GetUserClaimsByUserId(ApiSearchModel searchModel, CancellationToken cancellationToken);
    }
}
