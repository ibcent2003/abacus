using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Wbc.Application.Common.Interfaces
{
   public interface ICurrencyService
    {
        IEnumerable<Currency> GetCurrncy();

       
    }
}
