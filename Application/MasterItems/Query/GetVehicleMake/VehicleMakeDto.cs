using System.Collections.Generic;
using Wbc.Application.Common.Mappings;
using Wbc.Application.MasterItems.Query.GetVehicleMake;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Query.GetVehicleMake
{
    public class VehicleMakeDto : IMapFrom<VehicleMake>
    {
        //public VehicleMakeDto()
        //{
        //    vmodel = new List<VehicleModelDto>();
        //}

        public int Id { get; set; }
        public string MakeName { get; set; }
        public bool IsActive { get; set; }
      //  public IList<VehicleModelDto> vmodel { get; set; }
    }
}
