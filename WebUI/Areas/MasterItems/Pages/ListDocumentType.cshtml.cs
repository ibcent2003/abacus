using System.Threading.Tasks;
using Application.MasterItems.Query.GetDocumentType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanListDocumentType)]
    public class ListDocumentTypeModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<ListDocumentTypeModel> _stringLocalizer;
        public ListDocumentTypeModel(IMediator mediator, IStringLocalizer<ListDocumentTypeModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var query = new GetDocumentTypeListQuery
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
