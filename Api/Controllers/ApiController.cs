using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Wbc.Api.Configuration;

namespace Wbc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Policy = AuthorizationConsts.AdministrationPolicy)]
    [Produces("application/json", "application/problem+json")]
    public class ApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
