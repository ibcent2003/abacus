using System.Collections.Generic;
using Wbc.Application.MasterItems.Query.GetProcess;
using Wbc.Application.MasterItems.Query.GetRequiredDocument;

namespace Wbc.Application.MasterItems.Query.GetProcessRequiredDocument
{
    public class ProcessRequiredDocumentVm
    {
        public ProcessRequiredDocumentVm()
        {
            RequiredDocuments = new List<RequiredDocumentDto>();
            Processes = new List<ProcessDto>();
        }
        public IList<ProcessDto> Processes { get; set; }
        public ProcessDto ProcessDto { get; set; }
        public int SubscriberId { get; set; }
        public IList<RequiredDocumentDto> RequiredDocuments { get; set; }

    }
}
