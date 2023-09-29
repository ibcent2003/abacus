using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MenuResource.Commands.UpdateTopResource;

namespace Wbc.Application.MenuResource.Query.GetTopResource
{
    public class GetUpdateTopResourceCommandQuery : IRequest<UpdateTopResourceCommand>
    {
        public int Id { get; set; }
    }

    public class GetUpdateTopResourceCommandQueryHandler : IRequestHandler<GetUpdateTopResourceCommandQuery, UpdateTopResourceCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUpdateTopResourceCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateTopResourceCommand> Handle(GetUpdateTopResourceCommandQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.TopResources.FindAsync(request.Id);

            return _mapper.Map<UpdateTopResourceCommand>(entity);
        }
    }
}
