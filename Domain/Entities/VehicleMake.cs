using System.Collections.Generic;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class VehicleMake : AuditableEntity
    {        
        public int Id { get; set; }
        public string MakeName { get; set; }
        public bool IsActive { get; set; }      
    }
}
