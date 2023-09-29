using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Internal;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Dependencies
{
    public static class PolicyAuthorizationDependencyInjection
    {
        public static AuthorizationOptions AddCubeAuthorizationPolicy(this AuthorizationOptions policyOptions)
        {
            foreach (var pol in EnumHelper.GetValues<Policies>())
            {
                var policyClaims = pol.GetPolicyClaimValues();

                if (string.IsNullOrEmpty(policyClaims.PolicyName) || !policyClaims.RequiredRoles.Any() || !policyClaims.RequiredPermissions.Any()) continue;

                policyOptions.AddPolicy(policyClaims.PolicyName,
                    policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        policy.RequireAssertion(context => context.User.HasCubeClaims(policyClaims));

                    });
            }

            return policyOptions;
        }
    }
}