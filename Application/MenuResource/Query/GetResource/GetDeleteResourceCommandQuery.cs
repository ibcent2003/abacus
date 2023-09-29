using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MenuResource.Commands.DeleteResource;

namespace Wbc.Application.MenuResource.Query.GetResource
{
    public class GetDeleteResourceCommandQuery : IRequest<DeleteResourceCommand>
    {
        public int Id { get; set; }

    }

    public class GetDeleteResourceCommandQueryHandler : IRequestHandler<GetDeleteResourceCommandQuery, DeleteResourceCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDeleteResourceCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteResourceCommand> Handle(GetDeleteResourceCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Resources.Include(x => x.Permission).Include(x => x.Area).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var resourceDto = _mapper.Map<ResourceDto>(entity);

            return _mapper.Map<DeleteResourceCommand>(resourceDto);
        }
    }
}
