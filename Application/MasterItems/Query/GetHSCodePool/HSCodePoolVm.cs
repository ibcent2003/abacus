using Application.MasterItems.Command.UpdateHSCodePool;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.MasterItems.Query.GetCountry;

namespace Application.MasterItems.Query.GetHSCodePool
{
    public class HSCodePoolVm
    {
        public HSCodePoolVm()
        {
            Countries = new List<CountryDto>();
        }
        public IList<CountryDto> Countries { get; set; }
        public UpdateHSCodePoolCommand UpdateHSCodePoolCommand { get; set; }
    }
}
