using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Application.MasterItems.Query.GetProcessRequiredDocument;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Command.DeleteProcessRequiredDocument
{
    public class DeleteProcessRequiredDocumentCommand : IRequest, IMapFrom<SupportingDocumentDto>
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public string DocumentName { get; set; }
        public string ProcessCode { get; set; }
        public bool Mandatory { get; set; }
        public bool IsActive { get; set; }
    }

    public class DeleteProcessRequiredDocumentCommandHandler : IRequestHandler<DeleteProcessRequiredDocumentCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _userService;
        private readonly IDateTime _dateTime;

        public DeleteProcessRequiredDocumentCommandHandler(IApplicationDbContext context, ICurrentUserService userService, IDateTime dateTime)
        {
            _context = context;
            _userService = userService;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(DeleteProcessRequiredDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProcessRequiredDocuments.FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProcessRequiredDocument), request.Id);
            }

            _context.ProcessRequiredDocuments.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
