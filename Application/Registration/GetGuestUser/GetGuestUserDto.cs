using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Application.Registration.GetGuestUser
{
    public class GetGuestUserDto  :IMapFrom<GuestUser>
    {
        public int Id { get; set; }      
        public string ip { get; set; }
        public int NoOfused { get; set; }
        public DateTime AccessDate { get; set; }               
    }
}
