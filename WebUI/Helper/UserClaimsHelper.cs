using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Models;
using ClaimTypes = Wbc.Application.Common.Enums.ClaimTypes;


namespace Wbc.WebUI.Helper
{
    public static class UserClaimsHelper
    {
        private static string GetClaim(this ClaimsPrincipal claims, ClaimTypes claimTypes)
        {

            return claims.FindFirstValue(claimTypes.GetAttributeStringValue());

        }
        private static async Task<IList<string>> GetCubeRoleClaims(this ClaimsPrincipal claims)
        {
            var roles = claims.GetClaim(ClaimTypes.CubeRoles);

            try
            {
                var pareseRoles = JToken.Parse(roles);
            }
            catch
            {
                return new List<string>() { roles };
            }

            return await Task.FromResult(JsonConvert.DeserializeObject<IList<string>>(roles));
        }

        private static async Task<IList<string>> GetCubePermissionClaims(this ClaimsPrincipal claims)
        {
            var permissions = claims.GetClaim(ClaimTypes.Permissions);

            return await Task.FromResult(permissions.Split(",").ToList());
        }

        public static async Task<bool> HasCubeClaims(this ClaimsPrincipal claims, PolicyClaimValues claimValues)
        {

            var roles = await claims.GetCubeRoleClaims();

            var permissions = await claims.GetCubePermissionClaims();

            var requiredRoles = claimValues.RequiredRoles.Select(x => x.GetAttributeStringValue());

            var requiredPermissions = claimValues.RequiredPermissions.Select(x => x.GetAttributeStringValue());

            return roles.Any(x => requiredRoles.Contains(x)) && permissions.Any(x => requiredPermissions.Contains(x));


        }

    }
}
