using Application.MasterItems.Command.DeleteDocumentType;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;

namespace Application.MasterItems.Query.GetDocumentType
{
    public class GetDeleteDocumentTypeCommandQuery : IRequest<DeleteDocumentTypeCommand>
    {
        public int Id { get; set; }
    }

    public class GetDeleteDocumentTypeCommandQueryHandler : IRequestHandler<GetDeleteDocumentTypeCommandQuery, DeleteDocumentTypeCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDeleteDocumentTypeCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteDocumentTypeCommand> Handle(GetDeleteDocumentTypeCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.DocumentTypes.FindAsync(request.Id);

            return _mapper.Map<DeleteDocumentTypeCommand>(entity);
        }
    }
}
