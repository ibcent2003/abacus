using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wbc.Application.Common.Enums;
using Wbc.Application.MasterItems.Query.GetRequiredDocument;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanListRequiredDocument)]
    public class ListRequiredDocumentModel : PageModel
    {
        private readonly IMediator _mediator;

        public ListRequiredDocumentModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {

            var query = new GetRequiredDocumentListQuery
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
