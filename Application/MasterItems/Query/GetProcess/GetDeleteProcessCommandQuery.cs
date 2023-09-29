using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Command.DeleteProcess;

namespace Wbc.Application.MasterItems.Query.GetProcess
{
    public class GetDeleteProcessCommandQuery : IRequest<DeleteProcessCommand>
    {
        public int Id { get; set; }
    }

    public class GetDeleteProcessCommandQueryHandler : IRequestHandler<GetDeleteProcessCommandQuery, DeleteProcessCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDeleteProcessCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteProcessCommand> Handle(GetDeleteProcessCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Processes.FindAsync(request.Id);

            return _mapper.Map<DeleteProcessCommand>(entity);
        }
    }
}
