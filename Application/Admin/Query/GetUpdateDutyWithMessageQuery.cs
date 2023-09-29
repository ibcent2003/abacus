using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Admin.Command.UpdatePendingDuty;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.Admin.Query
{
    public class GetUpdateDutyWithMessageQuery : IRequest<UpdateDutyWithMessageCommand>
    {
        public Guid TransactionId { get; set; }
    }
    public class GetUpdateDutyWithMessageQueryHandler : IRequestHandler<GetUpdateDutyWithMessageQuery, UpdateDutyWithMessageCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public GetUpdateDutyWithMessageQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<UpdateDutyWithMessageCommand> Handle(GetUpdateDutyWithMessageQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.VehicleSearchPools.Where(x => x.TransactionId == request.TransactionId).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new NotFoundException(nameof(VehicleSearchPool), request.TransactionId);
            }           
            return _mapper.Map<UpdateDutyWithMessageCommand>(entity);

        }
    }
 }
