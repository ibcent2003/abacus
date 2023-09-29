using System;
using System.Collections.Generic;
using Wbc.Application.Common.Models;

namespace Wbc.Application.Workflow.Query.GetApprovalCommands
{
    public class ApprovalCommandsVm
    {
        public ApprovalCommandsVm()
        {
            DocumentTransitionHistoryDtos = new List<DocumentTransitionHistoryDto>();
            Commands = new DocumentCommandModel[0];
        }

        public IList<DocumentTransitionHistoryDto> DocumentTransitionHistoryDtos { get; set; }
        public DocumentCommandModel[] Commands { get; set; }
        public string DocumentSource { get; set; }
        public string SelectedCommand { get; set; }
        public string CurrentState { get; set; }
        public string Comments { get; set; }
        public Guid ProcessId { get; set; }

    }
}
