using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using ClaimTypes = System.Security.Claims.ClaimTypes;

namespace Wbc.WebUI.Services
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
            return _httpContext.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public int GetUserOrganisationId()
        {
            var result = _httpContext.HttpContext?.User?.FindFirstValue(Application.Common.Enums.ClaimTypes.SubscriptionClaim.GetAttributeStringValue());
            return Convert.ToInt32(result);
        }

        public string GetUserClaim(Application.Common.Enums.ClaimTypes claimTypes)
        {
            return _httpContext.HttpContext?.User?.FindFirst(x => x.Type.Equals(claimTypes.GetAttributeStringValue())).Value;
        }

        public IList<string> GetCurrentUserRoles()
        {
            var roles = _httpContext.HttpContext?.User?.FindFirst(x => x.Type.Equals("Role")).Value;

            try
            {
                var pareseRoles = JToken.Parse(roles);
            }
            catch
            {
                return new List<string>() { roles };
            }

            var roleList = JsonConvert.DeserializeObject<List<string>>(roles);

            return roleList;
        }

        public bool UserHasRole(Roles role)
        {
            var roles = GetCurrentUserRoles();

            return roles.Contains(role.GetAttributeStringValue());
        }

        public string GetUserName(string userId)
        {
            return _httpContext.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
        }


        public bool UserIsInRole(string role)
        {
            return GetCurrentUserRoles().Contains(role);
        }


    }
}
