using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MenuResource.Commands.DeleteTopResource;

namespace Wbc.Application.MenuResource.Query.GetTopResource
{
    public class GetDeleteTopResourceCommandQuery : IRequest<DeleteTopResourceCommand>
    {
        public int Id { get; set; }
    }

    public class GetDeleteTopResourceCommandQueryHandler : IRequestHandler<GetDeleteTopResourceCommandQuery, DeleteTopResourceCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDeleteTopResourceCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteTopResourceCommand> Handle(GetDeleteTopResourceCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.TopResources.FindAsync(request.Id);

            return _mapper.Map<DeleteTopResourceCommand>(entity);
        }
    }
}
