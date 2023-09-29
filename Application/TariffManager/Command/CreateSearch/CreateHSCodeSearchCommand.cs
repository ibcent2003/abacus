using Application.Common.Helper;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.TariffManager.Query.GetGlobalTariff;
using Wbc.Domain.Entities;

namespace Wbc.Application.TariffManager.Command.CreateSearch
{
    public class CreateHSCodeSearchCommand : IRequest<TarrifVm>
    {
        public string HScode { get; set; }
        public int CountryId { get; set; }
    }

    public class CreateHSCodeSearchCommandHandler : IRequestHandler<CreateHSCodeSearchCommand, TarrifVm>
    {

        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly ITariffManagerService _tariffManagerService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateHSCodeSearchCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, ITariffManagerService tariffManagerService, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _tariffManagerService = tariffManagerService;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<TarrifVm> Handle(CreateHSCodeSearchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.CountryId != 0 && request.HScode != null)
                {
                    var GetCountry = _context.Countries.FirstOrDefault(x => x.Id == request.CountryId);

                    var NoSplithsCode = await _context.HSCodePools.Include(x => x.Country).FirstOrDefaultAsync(x => x.Country.CountryName == GetCountry.CountryName && x.HSCode == request.HScode, cancellationToken);
                    if (NoSplithsCode != null)
                    {
                        var getTariff = await _context.tariffs.Include(x => x.HSCodeTariffTax).Where(x => x.HSCodePool.Country.CountryName == GetCountry.CountryName && x.HSCodePool.HSCode == request.HScode && x.HSCodeTariffTax.IsActive == true).ProjectTo<TariffDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                        return new TarrifVm
                        {
                            tariffDtos = getTariff,
                            hSCodePoolDto = _mapper.Map<HSCodePoolDto>(NoSplithsCode)
                        };
                    }
                    else
                    {
                        HsCodeSlipter slipter = new HsCodeSlipter();
                        var sliptedHsCode = slipter.Encode(request.HScode);
                        var hsCode = await _context.HSCodePools.Include(x => x.Country).FirstOrDefaultAsync(x => x.Country.CountryName == GetCountry.CountryName && x.HSCode == sliptedHsCode, cancellationToken);
                        if (hsCode != null)
                        {
                            var getTariff = await _context.tariffs.Include(x => x.HSCodeTariffTax).Where(x => x.HSCodePool.Country.CountryName == GetCountry.CountryName && x.HSCodePool.HSCode == sliptedHsCode && x.HSCodeTariffTax.IsActive == true).ProjectTo<TariffDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                            return new TarrifVm
                            {
                                tariffDtos = getTariff,
                                hSCodePoolDto = _mapper.Map<HSCodePoolDto>(hsCode)
                            };
                        }
                        else
                        {

                            var fvar = request.HScode.Substring(0, 4);
                            var svar = request.HScode.Substring(4, 2);
                            var tvar = request.HScode.Substring(6, 2);
                            var lvar = request.HScode.Substring(8);
                            var removeSlipt  = fvar.Replace(".","") + "" + svar.Replace(".", "") + "" + tvar.Replace(".", "").Replace(".", "") + "" + lvar.Replace(".", "");

                           /// var removeSlipt = slipter.Unencode(request.HScode);
                            var jointHscode = await _context.HSCodePools.Include(x => x.Country).FirstOrDefaultAsync(x => x.Country.CountryName == GetCountry.CountryName && x.HSCode == removeSlipt, cancellationToken);
                            if(jointHscode != null)
                            {
                                var getTariff = await _context.tariffs.Include(x => x.HSCodeTariffTax).Where(x => x.HSCodePool.Country.CountryName == GetCountry.CountryName && x.HSCodePool.HSCode == removeSlipt && x.HSCodeTariffTax.IsActive == true).ProjectTo<TariffDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                                return new TarrifVm
                                {
                                    tariffDtos = getTariff,
                                    hSCodePoolDto = _mapper.Map<HSCodePoolDto>(jointHscode)
                                };
                            }
                        }
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
