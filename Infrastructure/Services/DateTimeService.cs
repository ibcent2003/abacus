using Wbc.Application.Common.Interfaces;
using System;

namespace Wbc.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
