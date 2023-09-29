using System.Collections.Generic;
using Wbc.Application.MasterItems.Query.GetProcessRequiredDocument;

namespace Wbc.Application.Subscription.Query.GetSubscriber
{
    public class SubscriptionVm
    {
        public SubscriptionVm()
        {
            SupportingDocumentDtos = new List<SupportingDocumentDto>();
        }

        public IList<SupportingDocumentDto> SupportingDocumentDtos { get; set; }
    }
}
