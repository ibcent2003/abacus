
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.MasterItems.Command.UpdateVehicleModel;
using Wbc.Application.MasterItems.Query.GetVehicleMake;

namespace Wbc.Application.MasterItems.Query.GetVehicleModel
{
    public class VehicleModelVm
    {
        public IEnumerable<VehicleMakeDto> VehicleMakeList { get; set; }
        public UpdateVehicleModelCommand UpdateCommand { get; set; }
    }
}
