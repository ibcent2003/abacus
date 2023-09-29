using Application.MasterItems.Query.GetHSCodePool;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Command.DeleteHSCodePool
{
    public class DeleteHSCodePoolCommand : IRequest, IMapFrom<HSCodePoolDto>
    {
        public int Id { get; set; }
        public string HSCode { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string StandardUnitOfQuantity { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
    }

    public class DeleteHSCodePoolCommandHandler : IRequestHandler<DeleteHSCodePoolCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteHSCodePoolCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(DeleteHSCodePoolCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.HSCodePools.Where(l => l.Id == request.Id)

                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(HSCodePool), request.Id);
            }

            entity.IsActive = false;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
