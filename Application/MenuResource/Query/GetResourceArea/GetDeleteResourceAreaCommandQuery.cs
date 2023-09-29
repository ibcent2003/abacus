using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MenuResource.Commands.DeleteResourceArea;

namespace Wbc.Application.MenuResource.Query.GetResourceArea
{
    public class GetDeleteResourceAreaCommandQuery : IRequest<DeleteResourceAreaCommand>
    {
        public int Id { get; set; }
    }

    public class GetDeleteResourceAreaCommandQueryHandler : IRequestHandler<GetDeleteResourceAreaCommandQuery, DeleteResourceAreaCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDeleteResourceAreaCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteResourceAreaCommand> Handle(GetDeleteResourceAreaCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ResourceAreas.Include(x => x.Parent).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var resourceAreaDto = _mapper.Map<ResourceAreaDto>(entity);

            return _mapper.Map<DeleteResourceAreaCommand>(resourceAreaDto);
        }
    }
}
