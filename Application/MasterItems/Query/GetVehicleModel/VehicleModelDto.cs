using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Application.MasterItems.Query.GetVehicleMake;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Query.GetVehicleModel
{
   public class VehicleModelDto : IMapFrom<VehicleModel>
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int VehicleMakeId { get; set; }
        public VehicleMakeDto VehicleMake { get; set; }
        public string MakeName { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VehicleModel, VehicleModelDto>()
                .ForMember(d => d.MakeName, opt => opt.MapFrom(s => s.VehicleMake.MakeName));               
        }
    }
}
