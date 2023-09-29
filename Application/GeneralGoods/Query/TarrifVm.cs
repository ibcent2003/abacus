using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.GeneralGoods.Query;

namespace Wbc.Application.GeneralGoods.Query
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
