using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Command.UpdateProcess
{
    public class UpdateProcessCommand : IRequest, IMapFrom<Domain.Entities.Process>
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string ProcessDescription { get; set; }
        public string ProcessCode { get; set; }
        public bool IsInternalUse { get; set; }
    }


    public class UpdateProcessCommandHandler : IRequestHandler<UpdateProcessCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProcessCommandHandler(IApplicationDbContext context, AdminConfiguration adminConfiguration)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProcessCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Processes.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Process), request.Id);
            }

            entity.ProcessName = request.ProcessName;
            entity.IsInternal = request.IsInternalUse;
            entity.ProcessDescription = request.ProcessDescription;
            entity.ProcessCode = request.ProcessCode;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }

}
