using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;

namespace Wbc.Infrastructure.Services
{
    public class SsoService : ISsoService
    {
        private readonly AdminConfiguration _adminConfiguration;
        private readonly SsoServiceConfiguration _ssoServiceConfiguration;
        private readonly IWbcSsoHttpClientService _clientService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ICurrentUserService _currentUserService;

        public SsoService(AdminConfiguration adminConfiguration, SsoServiceConfiguration ssoServiceConfiguration, IWbcSsoHttpClientService clientService, IHttpContextAccessor httpContext, ICurrentUserService currentUserService)
        {
            _adminConfiguration = adminConfiguration;
            _ssoServiceConfiguration = ssoServiceConfiguration;
            _clientService = clientService;
            _httpContext = httpContext;
            _currentUserService = currentUserService;
        }

        public async Task<UserInfoResponse> GetUserInfo(CancellationToken cancellationToken)
        {
            var tokenResponse = await _httpContext.HttpContext.GetTokenAsync("access_token");

            return await _clientService.GetUserInfoAsync(tokenResponse, cancellationToken);
        }

        public async Task<string> GetUserClaimValue(ClaimTypes claimType, CancellationToken cancellationToken)
        {

            var claim = claimType.GetAttributeStringValue();
            var claims = await GetUserInfo(cancellationToken);
            var claimValue = claims.Claims.First(x => x.Type == claim).Value;
            return claimValue;

        }

        public async Task<User> AddUserAsync(User user, CancellationToken cancellationToken)
        {

            var postUrl = $"{_ssoServiceConfiguration.SsoServiceBaseUrl}{_ssoServiceConfiguration.AddUserPostUrl}";
            return await _clientService.PostWithTokenAsync<User>(user, _adminConfiguration.SsoApiScope, postUrl, cancellationToken);
        }

        public async Task<HttpStatusCode> AddUserToRoleAsync(UserRole userRole, CancellationToken cancellationToken)
        {

            var postUrl = $"{_ssoServiceConfiguration.SsoServiceBaseUrl}{_ssoServiceConfiguration.AddUserRolePostUrl}";
            var response = await _clientService.PostWithTokenAsync(userRole, _adminConfiguration.SsoApiScope, postUrl, cancellationToken);
            return response.StatusCode;
        }

        public async Task<HttpStatusCode> ChangePasswordAsync(ChangePassword changePassword, CancellationToken cancellationToken)
        {
            var postUrl = $"{_ssoServiceConfiguration.SsoServiceBaseUrl}{_ssoServiceConfiguration.ChangePassword}";
            var response = await _clientService.PostWithTokenAsync(changePassword, _adminConfiguration.SsoApiScope, postUrl, cancellationToken);
            return response.StatusCode;
        }

        public async Task<HttpStatusCode> AddClaimToUserAsync(UserClaim userClaim, CancellationToken cancellationToken)
        {
            var postUrl = $"{_ssoServiceConfiguration.SsoServiceBaseUrl}{_ssoServiceConfiguration.AddClaimToUserPostUrl}";
            var response = await _clientService.PostWithTokenAsync(userClaim, _adminConfiguration.SsoApiScope, postUrl, cancellationToken);
            return response.StatusCode;
        }

        public async Task<HttpStatusCode> AddRangeClaimToUserAsync(ClaimList userClaims, CancellationToken cancellationToken)
        {
            var postUrl = $"{_ssoServiceConfiguration.SsoServiceBaseUrl}{_ssoServiceConfiguration.AddClaimListToUserPostUrl}";
            var response = await _clientService.PostWithTokenAsync(userClaims, _adminConfiguration.SsoApiScope, postUrl, cancellationToken);
            return response.StatusCode;
        }

        public async Task<UserQueryListResult> GetUsersAsync(ApiSearchModel searchModel, CancellationToken cancellationToken)
        {
            var postUrl = $"{_ssoServiceConfiguration.SsoServiceBaseUrl}{_ssoServiceConfiguration.GetUsersUrl}?searchText={searchModel.SearchText}&page={searchModel.Page}&pageSize={searchModel.PageSize}";
            var response = await _clientService.GetWithTokenAsync<UserQueryListResult>(_adminConfiguration.SsoApiScope, postUrl, cancellationToken);
            return response;
        }



        public async Task<RoleQueryListResult> GetRolesAsync(ApiSearchModel searchModel, CancellationToken cancellationToken)
        {
            var postUrl = $"{_ssoServiceConfiguration.SsoServiceBaseUrl}{_ssoServiceConfiguration.GetRolesUrl}?searchText={searchModel.SearchText}&page={searchModel.Page}&pageSize={searchModel.PageSize}";
            var response = await _clientService.GetWithTokenAsync<RoleQueryListResult>(_adminConfiguration.SsoApiScope, postUrl, cancellationToken);
            return response;
        }

        public async Task<UserQueryListResult> GetUsersByClaimAsync(ApiSearchModel searchModel, CancellationToken cancellationToken)
        {
            var orgId = _currentUserService.GetUserOrganisationId();
            var postUrl = $"{_ssoServiceConfiguration.SsoServiceBaseUrl}{_ssoServiceConfiguration.GetUsersByOrgPostUrl}/{searchModel.ClaimType}/ClaimValue/{searchModel.ClaimValue}/OrganisationId/{orgId}?page={searchModel.Page}&pageSize={searchModel.PageSize}";
            var response = await _clientService.GetWithTokenAsync<UserQueryListResult>(_adminConfiguration.SsoApiScope, postUrl, cancellationToken);
            return response;
        }

        public async Task<ClaimList> GetUserClaimsByUserId(ApiSearchModel searchModel, CancellationToken cancellationToken)
        {
            var postUrl = $"{_ssoServiceConfiguration.SsoServiceBaseUrl}{_ssoServiceConfiguration.GetUserClaimByUserIdPostUrl}/{searchModel.Id}/Claims";

            var response = await _clientService.GetWithTokenAsync<ClaimList>(_adminConfiguration.SsoApiScope, postUrl, cancellationToken);

            return response;
        }
    }
}
