﻿using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Command.DeleteRequiredDocument;

namespace Wbc.Application.MasterItems.Query.GetRequiredDocument
{
    public class GetDeleteRequiredDocumentCommandQuery : IRequest<DeleteRequiredDocumentCommand>
    {
        public int Id { get; set; }
    }

    public class GetDeleteRequiredDocumentCommandQueryHandler : IRequestHandler<GetDeleteRequiredDocumentCommandQuery, DeleteRequiredDocumentCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetDeleteRequiredDocumentCommandQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<DeleteRequiredDocumentCommand> Handle(GetDeleteRequiredDocumentCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.RequiredDocuments.FindAsync(request.Id);

            if (_currentUserService.UserHasRole(Roles.TradeHubAdmin) && entity.SubscriberId.HasValue) throw new NotFoundException(nameof(entity), request.Id);

            if (_currentUserService.UserHasRole(Roles.TradeHubAdmin)) return _mapper.Map<DeleteRequiredDocumentCommand>(entity);

            var orgId = _currentUserService.GetUserOrganisationId();

            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.ParentId == orgId, cancellationToken);

            if (entity.SubscriberId != subscriber.Id) throw new NotFoundException(nameof(entity), request.Id);

            return _mapper.Map<DeleteRequiredDocumentCommand>(entity);
        }

    }
}
