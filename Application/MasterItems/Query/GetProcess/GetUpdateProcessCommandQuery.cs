using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Command.UpdateProcess;

namespace Wbc.Application.MasterItems.Query.GetProcess
{

    public class GetUpdateProcessCommandQuery : IRequest<UpdateProcessCommand>
    {
        public int Id { get; set; }
    }

    public class GetUpdateProcessCommandQueryHandler : IRequestHandler<GetUpdateProcessCommandQuery, UpdateProcessCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetUpdateProcessCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateProcessCommand> Handle(GetUpdateProcessCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Processes.FindAsync(request.Id);

            return _mapper.Map<UpdateProcessCommand>(entity);
        }
    }
}
