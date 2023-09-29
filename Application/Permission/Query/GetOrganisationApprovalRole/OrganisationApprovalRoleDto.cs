using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.Permission.Query.GetOrganisationApprovalRole
{
    public class OrganisationApprovalRoleDto : IMapFrom<OrganisationApprovalRole>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public int? SubcriberId { get; set; }
        public bool IsInternalUse { get; set; }
        public string SubscriberName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrganisationApprovalRole, OrganisationApprovalRoleDto>()
                .ForMember(d => d.SubcriberId, opt => opt.MapFrom(s => s.Subscriber.Id))
                .ForMember(d => d.SubscriberName, opt => opt.MapFrom(s => s.Subscriber.EntityName));
        }
    }
}
