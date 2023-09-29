using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.TariffManager.Query.GetGlobalTariff
{
   public class GetTariffHSCodeCountryQuery : IRequest<TarrifVm>
    {
        public string hScode { get; set; }
        public string CountryName { get; set; }
        public int countryId { get; set; }
    }
    public class GetTariffHSCodeCountryQueryHandler : IRequestHandler<GetTariffHSCodeCountryQuery, TarrifVm>
    {

        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly ITariffManagerService _tariffManagerService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetTariffHSCodeCountryQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService, ITariffManagerService tariffManagerService, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _tariffManagerService = tariffManagerService;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<TarrifVm> Handle(GetTariffHSCodeCountryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.CountryName !=null && request.hScode != null)
                {
                    var hsCode = await _context.HSCodePools.Include(x => x.Country).FirstOrDefaultAsync(x => x.Country.CountryName == request.CountryName && x.HSCode ==request.hScode, cancellationToken);
                   if(hsCode != null)
                    {
                        var getTariff = await _context.tariffs.Include(x => x.HSCodeTariffTax).Where(x => x.HSCodePool.Country.CountryName == request.CountryName && x.HSCodePool.HSCode == request.hScode && x.HSCodeTariffTax.IsActive==true).ProjectTo<TariffDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken); //_context.HSCodePools.Include(x=>x.Tariffs).Include(x=>x.Country).FirstOrDefaultAsync(x => x.CountryId == request.id);
                        return new TarrifVm
                        {
                            tariffDtos = getTariff,
                            hSCodePoolDto = _mapper.Map<HSCodePoolDto>(hsCode)
                        };
                    }
                   
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
 }
