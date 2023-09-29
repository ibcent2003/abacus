using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Enums;

namespace Wbc.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {

        private readonly IHttpContextAccessor _httpContext;

        public CurrentUserService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public string GetUserId()
        {
            return _httpContext.HttpContext?.User?.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier);
        }

        public string GetUserClaim(Wbc.Application.Common.Enums.ClaimTypes claimTypes)
        {
            return _httpContext.HttpContext?.User?.FindFirst(x => x.Type.Equals(claimTypes.GetAttributeStringValue())).Value;
        }

        public IList<string> GetCurrentUserRoles()
        {
            var roles = _httpContext.HttpContext?.User?.FindFirst(x => x.Type.Equals("Role")).Value;

            var roleList = JsonConvert.DeserializeObject<List<string>>(roles);
            return roleList;
        }

        public string GetUserName(string userId)
        {
            return _httpContext.HttpContext?.User?.FindFirstValue(System.Security.Claims.ClaimTypes.Name);
        }

        public bool UserIsInRole(string role)
        {
            return GetCurrentUserRoles().Contains(role);
        }

        public int GetUserOrganisationId()
        {
            throw new System.NotImplementedException();
        }

        public string GetUserName()
        {
            throw new System.NotImplementedException();
        }

        public bool UserHasRole(Roles role)
        {
            throw new System.NotImplementedException();
        }
    }
}
