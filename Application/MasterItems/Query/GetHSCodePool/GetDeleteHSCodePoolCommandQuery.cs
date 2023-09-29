using Application.MasterItems.Command.DeleteHSCodePool;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;

namespace Application.MasterItems.Query.GetHSCodePool
{
   public class GetDeleteHSCodePoolCommandQuery : IRequest<DeleteHSCodePoolCommand>
    {
        public int Id { get; set; }
    }

    public class GetDeleteHSCodePoolCommandQueryHandler : IRequestHandler<GetDeleteHSCodePoolCommandQuery, DeleteHSCodePoolCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDeleteHSCodePoolCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteHSCodePoolCommand> Handle(GetDeleteHSCodePoolCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.HSCodePools.Include(x => x.Country).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var hsCodeDto = _mapper.Map<HSCodePoolDto>(entity);

            return _mapper.Map<DeleteHSCodePoolCommand>(hsCodeDto);
        }
    }
}
