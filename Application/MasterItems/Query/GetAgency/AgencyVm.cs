using Application.MasterItems.Command.UpdateAgency;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Models;

namespace Application.MasterItems.Query.GetAgency
{
    public class AgencyVm
    {

        public FileUploadModel LogoUploaded { get; set; }
        public AgencyDto AgencyDto { get; set; }
        public UpdateAgencyCommand UpdateAgency { get; set; }
    }
}
