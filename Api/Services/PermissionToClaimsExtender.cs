using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Wbc.Application.Permission.Query.GetPermission;

namespace Wbc.Api.Services
{
    public class PermissionToClaimsExtender : IClaimsTransformation
    {

        private readonly IMediator _mediator;
        public PermissionToClaimsExtender(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {

            if (!principal.Identity.IsAuthenticated) return await Task.FromResult(principal);

            var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

            var permissions = await _mediator.Send(new GetUserPermissionsQuery { UserId = userId });


            if (principal.HasClaim(x => x.Type == "Permissions")) return await Task.FromResult(principal);

            var claims = new List<Claim> { new Claim("Permissions", permissions) };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            principal.AddIdentity(identity);



            return await Task.FromResult(principal);
        }
    }
}
