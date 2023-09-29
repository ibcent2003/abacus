using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.MasterItems.Command.CreateProcess
{
    public class AddProcessCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string ProcessDescription { get; set; }
        public string ProcessCode { get; set; }
        public bool IsInternalUse { get; set; }
    }

    public class AddProcessCommandHandler : IRequestHandler<AddProcessCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public AddProcessCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddProcessCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Process
            {
                ProcessName = request.ProcessName,
                ProcessDescription = request.ProcessName,
                ProcessCode = request.ProcessCode,
                IsActive = true,
                IsInternal = request.IsInternalUse

            };

            _context.Processes.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
