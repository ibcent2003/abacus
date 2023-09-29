using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.TariffManager.Query.GetGlobalTariff;

namespace Wbc.Application.TariffManager.Query.GetGlobalTariff
{
    public class TarrifVm
    {
        public TarrifVm()
        {
            tariffDtos = new List<TariffDto>();
        }
        public HSCodePoolDto hSCodePoolDto { get; set; }
        public IList<TariffDto> tariffDtos { get; set; }
    }
}
