using System.Collections.Generic;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class Process : AuditableEntity
    {
        public Process()
        {
            ProcessRequiredDocuments = new List<ProcessRequiredDocument>();
        }
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string ProcessDescription { get; set; }
        public IList<ProcessRequiredDocument> ProcessRequiredDocuments { get; set; }
        public string ProcessCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsInternal { get; set; }
        public string ProcessLocalizationKey { get; set; }

    }
}
