using System;
using System.Collections.Generic;
using System.Text;

namespace Application.MasterItems.Query.GetAgency
{
    public class AgencyDto
    {
        public int Id { get; set; }
        public string AgencyName { get; set; }
        public string Logo { get; set; }
        public string AgencyCode { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
