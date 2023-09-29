using System;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.Common.Models
{
    public class DocumentDto : IMapFrom<Document>
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string StateName { get; set; }
        public Guid WorkflowProcessId { get; set; }
    }
}
