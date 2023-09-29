using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class WorkFlowInstanceCreateModel : IPayLoadObject
    {
        public WorkFlowInstanceCreateModel(string processId, string schemeCode)
        {
            ProcessId = processId;
            SchemeCode = schemeCode;
        }

        public string ProcessId { get; set; }
        public string State { get; set; }
        public string SchemeCode { get; set; }
        public string Command { get; set; }
        public string IdentityId { get; set; }
        public string ImpersonatedIdentityId { get; set; }
        public string SchemeParameters { get; set; }
        public object ProcessParameters { get; set; }
        public string TenantId { get; set; }
        public string Persist { get; set; }

    }
}
