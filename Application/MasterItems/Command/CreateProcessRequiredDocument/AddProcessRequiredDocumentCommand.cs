using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Command.CreateProcessRequiredDocument
{
    public class AddProcessRequiredDocumentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public int RequiredDocumentId { get; set; }
        public string ProcessCode { get; set; }
        public bool Mandatory { get; set; }
        public bool IsActive { get; set; }
        public bool IsInternalUse { get; set; }
        public int? SubscriberId { get; set; }
        public string ProcessName { get; set; }

    }

    public class AddProcessRequiredDocumentCommandHandler : IRequestHandler<AddProcessRequiredDocumentCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public AddProcessRequiredDocumentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddProcessRequiredDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = new ProcessRequiredDocument
            {
                ProcessId = request.ProcessId,
                SubscriberId = request.SubscriberId == 0 ? null : request.SubscriberId,
                ProcessCode = request.ProcessCode,
                RequiredDocumentId = request.RequiredDocumentId,
                Mandatory = request.Mandatory,
                IsActive = true
            };


            _context.ProcessRequiredDocuments.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }


    }
}
