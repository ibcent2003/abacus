using Application.MasterItems.Command.UpdateDocumentType;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;

namespace Application.MasterItems.Query.GetDocumentType
{
    public class GetUpdateDocumentTypeCommandQuery : IRequest<UpdateDocumentTypeCommand>
    {
        public int Id { get; set; }
    }


    public class GetUpdateDocumentTypeCommandQueryHandler : IRequestHandler<GetUpdateDocumentTypeCommandQuery, UpdateDocumentTypeCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetUpdateDocumentTypeCommandQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<UpdateDocumentTypeCommand> Handle(GetUpdateDocumentTypeCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.DocumentTypes.FindAsync(request.Id);

            return _mapper.Map<UpdateDocumentTypeCommand>(entity);
        }
    }
}
