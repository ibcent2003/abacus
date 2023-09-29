using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.MasterItems.Command.CreateProcessRequiredDocument;
using Wbc.Application.MasterItems.Query.GetProcessRequiredDocument;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanAddProcessRequiredDocument)]
    public class AddProcessRequiredDocumentModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AddProcessRequiredDocumentModel> _stringLocalizer;

        public AddProcessRequiredDocumentModel(IMediator mediator, IStringLocalizer<AddProcessRequiredDocumentModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [BindProperty]
        public AddProcessRequiredDocumentCommand Command { get; set; }
        public SelectList RequiredDocumentList { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {

            var processRequiredDocumentVm = await _mediator.Send(new GetAddProcessRequiredDocumentQuery { ProcessId = id });

            var prCommand = new AddProcessRequiredDocumentCommand
            {
                ProcessId = processRequiredDocumentVm.ProcessDto.Id,
                IsInternalUse = processRequiredDocumentVm.ProcessDto.IsInternalUse,
                ProcessName = processRequiredDocumentVm.ProcessDto.ProcessName,
                SubscriberId = processRequiredDocumentVm.SubscriberId,
                ProcessCode = processRequiredDocumentVm.ProcessDto.ProcessCode
            };

            Command = prCommand;
            RequiredDocumentList = new SelectList(processRequiredDocumentVm.RequiredDocuments, "Id", "DocumentName");

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                var processRequiredDocumentVm = await _mediator.Send(new GetAddProcessRequiredDocumentQuery { ProcessId = Command.ProcessId });

                RequiredDocumentList = new SelectList(processRequiredDocumentVm.RequiredDocuments, "Id", "DocumentName");

                return Page();
            }

            var dummy = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            var vm = await _mediator.Send(new GetAddProcessRequiredDocumentQuery { ProcessId = Command.ProcessId });

            RequiredDocumentList = new SelectList(vm.RequiredDocuments, "Id", "DocumentName");

            return Page();
        }
    }
}
