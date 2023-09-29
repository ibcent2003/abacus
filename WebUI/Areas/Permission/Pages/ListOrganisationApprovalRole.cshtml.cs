using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wbc.Application.Common.Enums;
using Wbc.Application.Permission.Query.GetOrganisationApprovalRole;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.Permission.Pages
{
    [AuthorizePolicy(Policies.CanListOrganisationApprovalRole)]
    public class ListOrganisationApprovalRoleModel : PageModel
    {
        private readonly IMediator _mediator;

        public ListOrganisationApprovalRoleModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var query = new GetOrgaisationApprovalRoleListQuery()
            {
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
