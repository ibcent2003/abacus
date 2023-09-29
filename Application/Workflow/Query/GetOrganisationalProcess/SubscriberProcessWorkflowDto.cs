using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.Workflow.Query.GetOrganisationalProcess
{
    public class SubscriberProcessWorkflowDto : IMapFrom<SubscriberProcessWorkflow>
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public int SubscriberId { get; set; }
        public string WorkflowSchemeCode { get; set; }

    }
}
