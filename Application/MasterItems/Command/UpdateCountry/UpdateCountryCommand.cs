using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Command.UpdateCountry
{
    public class UpdateCountryCommand : IRequest, IMapFrom<Country>
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdateCounryCommandHandler : IRequestHandler<UpdateCountryCommand>
    {

        private readonly IApplicationDbContext _context;
        public UpdateCounryCommandHandler(IApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<Unit> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Countries.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Country), request.Id);
            }

            entity.CountryName = request.CountryName;
            entity.CountryCode = request.CountryCode;
            entity.CurrencyName = request.CurrencyName;
            entity.CurrencyCode = request.CurrencyCode;
            entity.IsActive = request.IsActive;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
