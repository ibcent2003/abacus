using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IDepreciationService
    {
        decimal CalDepreciation(int year, decimal hdv, string half);
    }
}
