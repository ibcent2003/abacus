using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class VehicleModel : AuditableEntity
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public bool IsActive { get; set; }
        public int VehicleMakeId { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }


    }
}
