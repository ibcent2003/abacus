using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Application.TariffManager.Query.GetGlobalTariff
{
   public class GetTariffClient : IRequest<TarrifVm>
    {
        public string hscode { get; set; }
        public int countryId { get; set; }
    }
}
