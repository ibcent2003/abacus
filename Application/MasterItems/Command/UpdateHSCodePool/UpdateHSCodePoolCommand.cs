using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Command.UpdateHSCodePool
{
   public class UpdateHSCodePoolCommand : IRequest, IMapFrom<HSCodePool>
    {
        public int Id { get; set; }
        public string HSCode { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string StandardUnitOfQuantity { get; set; }
        public int CountryId { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateHSCodePoolCommandHandler : IRequestHandler<UpdateHSCodePoolCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateHSCodePoolCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateHSCodePoolCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.HSCodePools.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(HSCodePool), request.Id);
            }

            entity.HSCode = request.HSCode;
            entity.Heading = request.Heading;
            entity.Description = request.Description;
            entity.StandardUnitOfQuantity = request.StandardUnitOfQuantity;
            entity.CountryId = request.CountryId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
