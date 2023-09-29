using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MenuResource.Commands.UpdateResourceArea;
using Wbc.Application.MenuResource.Query.GetTopResource;

namespace Wbc.Application.MenuResource.Query.GetResourceArea
{
    public class GetUpdateResourceAreaCommandQuery : IRequest<ResourceAreaVm>
    {
        public int Id { get; set; }
    }

    public class GetUpdateResourceAreaCommandQueryHandler : IRequestHandler<GetUpdateResourceAreaCommandQuery, ResourceAreaVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUpdateResourceAreaCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResourceAreaVm> Handle(GetUpdateResourceAreaCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ResourceAreas.FindAsync(request.Id);

            return new ResourceAreaVm
            {
                UpdateCommand = _mapper.Map<UpdateResourceAreaCommand>(entity),
                ResourceHeaders = await _context.TopResources.Where(x => x.IsActive).ProjectTo<TopResourceDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
