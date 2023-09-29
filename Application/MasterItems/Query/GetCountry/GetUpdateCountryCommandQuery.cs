using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Command.UpdateCountry;


namespace Wbc.Application.MasterItems.Query.GetCountry
{
    public class GetUpdateCountryCommandQuery : IRequest<UpdateCountryCommand>
    {
        public int Id { get; set; }
    }

    public class GetUpdateCountryCommandQueryHandler : IRequestHandler<GetUpdateCountryCommandQuery, UpdateCountryCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUpdateCountryCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateCountryCommand> Handle(GetUpdateCountryCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Countries.FindAsync(request.Id);

            return _mapper.Map<UpdateCountryCommand>(entity);
        }
    }
}
