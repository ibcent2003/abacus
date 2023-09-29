using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.MasterItems.Command.CreateCountry
{
   public class AddCountryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
    }
    public class AddCountryCommandHandler : IRequestHandler<AddCountryCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public AddCountryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Country
            {
                CountryName = request.CountryName,
                CountryCode = request.CountryCode,
                CurrencyName = request.CurrencyName,
                CurrencyCode = request.CountryCode,
                IsActive = true
            };
            _context.Countries.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
