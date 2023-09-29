using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wbc.Application.Common.Enums;
using Wbc.Application.Permission.Query.GetPermission;
using Wbc.WebUI.Filter;

namespace Wbc.WebUI.Areas.Permission.Pages
{
    [AuthorizePolicy(Policies.CanViewOrganisationalUserDetails)]
    public class GetPermissionTreeModel : PageModel
    {
        private readonly IMediator _mediator;
        public GetPermissionTreeModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var oList = await _mediator.Send(new GetPermissionTreeQuery { Id = id });

            return new JsonResult(oList);
        }
    }
}
