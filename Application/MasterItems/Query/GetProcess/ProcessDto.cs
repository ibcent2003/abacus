using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;

namespace Wbc.Application.MasterItems.Query.GetProcess
{


    public class ProcessDto : IMapFrom<Domain.Entities.Process>
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string ProcessDescription { get; set; }
        public string ProcessCode { get; set; }
        public bool IsInternalUse { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Process, ProcessDto>()
                .ForMember(d => d.ProcessName, opt => opt.MapFrom(s => s.ProcessName))
                .ForMember(x => x.ProcessDescription, opt => opt.MapFrom(s => s.ProcessDescription))
                .ForMember(x => x.ProcessCode, opt => opt.MapFrom(s => s.ProcessCode));

        }
    }
}
