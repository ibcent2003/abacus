using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Permission.Query.GetPermission;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.Permission.Pages
{
    [AuthorizePolicy(Policies.CanListOrganisationalUsers)]
    public class OrganisationalUsersModel : PageModel
    {
        private readonly IMediator _mediator;

        public OrganisationalUsersModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            var claimType = ClaimTypes.SubscriptionClaim.GetAttributeStringValue();

            var query = new GetUsersListQuery
            {
                ClaimType = claimType,
                ClaimValue = string.IsNullOrEmpty(this.GetDataTableSearchValue()) ? "@" : this.GetDataTableSearchValue(),
                draw = this.GetDataTableDrawValue(),
                start = this.GetDataTableStartValue(),
                length = this.GetDataTableLenghtValue(),
                sortDirection = this.GetDataTableSortColumnDirection(),
                sortColumn = this.GetDataTableSortColumn(),
                search = this.GetDataTableSearchValue()
            };

            var dataTableData = await _mediator.Send(query);

            return new JsonResult(dataTableData);
        }
    }
}
