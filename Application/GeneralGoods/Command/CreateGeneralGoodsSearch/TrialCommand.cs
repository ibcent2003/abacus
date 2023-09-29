using Application.Common.Helper;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.GeneralGoods.Command.CreateGeneralGoodsSearch
{
   public class TrialCommand : IRequest<UserHSCodePool>
    {
        public string HsCode { get; set; }
        public decimal FOB { get; set; }
        public decimal Freight { get; set; }
        public decimal Insurance { get; set; }
        public int CurrencyId { get; set; }
        public int CountryId { get; set; }
        public int ExportingCountryId { get; set; }
        public string Keyword { get; set; }
        public string ContainerSize { get; set; }
        public string GuestCookie { get; set; }
    }

    public class TrialCommandHanlder : IRequestHandler<TrialCommand, UserHSCodePool>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IGeneralGoodsService _generalGoodsService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IVehicleService _vehicleService;

        public TrialCommandHanlder(IApplicationDbContext context, ICurrentUserService currentUserService, IGeneralGoodsService generalGoodsService, IMediator mediator, IMapper mapper, IVehicleService vehicleService)
        {
            _context = context;
            _currentUserService = currentUserService;
            _generalGoodsService = generalGoodsService;
            _mediator = mediator;
            _mapper = mapper;
            _vehicleService = vehicleService;
        }       

        public async Task<UserHSCodePool> Handle(TrialCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var exchangeRate = await _context.ExchangeRates.Where(x => x.CurrencyId == request.CurrencyId && x.CountryId == request.CountryId).OrderByDescending(x => x.Week).FirstOrDefaultAsync();
                if (null == exchangeRate)
                {
                    return null;
                }
              
                HsCodeSlipter slipter = new HsCodeSlipter();
                var sliptedHsCode = slipter.Encode(request.HsCode);

                var GetCountry = _context.Countries.FirstOrDefault(x => x.Id == request.CountryId);

                var NoSplithsCode = await _context.HSCodePools.Include(x => x.Country).FirstOrDefaultAsync(x => x.Country.CountryName == GetCountry.CountryName && x.HSCode == request.HsCode, cancellationToken);
                if (NoSplithsCode != null)
                {
                    #region Ghana Calculation
                    if (GetCountry.CountryCode == "GH")
                    {
                        var duty = await _generalGoodsService.GeneralGoodsTrialGhana(request.GuestCookie,NoSplithsCode.Id, NoSplithsCode.HSCode, request.FOB, request.Freight, request.Insurance, request.CurrencyId, GetCountry.Id, NoSplithsCode.StandardUnitOfQuantity, request.ExportingCountryId, request.Keyword, request.ContainerSize, cancellationToken);
                        return duty;
                    }
                    #endregion

                    #region Nigeria Calculation
                    if (GetCountry.CountryCode == "NGN")
                    {
                        var duty = await _generalGoodsService.GeneralGoodsTrialNigeria(request.GuestCookie, NoSplithsCode.Id, NoSplithsCode.HSCode, request.FOB, request.Freight, request.Insurance, request.CurrencyId, GetCountry.Id, NoSplithsCode.StandardUnitOfQuantity, request.ExportingCountryId, request.Keyword, request.ContainerSize, cancellationToken);
                        return duty;
                    }
                    #endregion                                  
                }
                else
                {
                    var hsCode = await _context.HSCodePools.Include(x => x.Country).FirstOrDefaultAsync(x => x.Country.CountryName == GetCountry.CountryName && x.HSCode == sliptedHsCode, cancellationToken);
                    if (hsCode != null)
                    {
                        #region Ghana Calculation
                        if (GetCountry.CountryCode == "GH")
                        {
                            var duty = await _generalGoodsService.GeneralGoodsTrialGhana(request.GuestCookie,NoSplithsCode.Id, NoSplithsCode.HSCode, request.FOB, request.Freight, request.Insurance, request.CurrencyId, GetCountry.Id, NoSplithsCode.StandardUnitOfQuantity, request.ExportingCountryId, request.Keyword, request.ContainerSize, cancellationToken);
                            return duty;
                        }
                        #endregion

                        #region Nigeria Calculation
                        if (GetCountry.CountryCode == "NGN")
                        {
                            var duty = await _generalGoodsService.GeneralGoodsTrialNigeria(request.GuestCookie,NoSplithsCode.Id, NoSplithsCode.HSCode, request.FOB, request.Freight, request.Insurance, request.CurrencyId, GetCountry.Id, NoSplithsCode.StandardUnitOfQuantity, request.ExportingCountryId, request.Keyword, request.ContainerSize, cancellationToken);
                            return duty;
                        }
                        #endregion
                        //else do for other countries
                    }
                    else
                    {
                        var fvar = request.HsCode.Substring(0, 4);
                        var svar = request.HsCode.Substring(4, 2);
                        var tvar = request.HsCode.Substring(6, 2);
                        var lvar = request.HsCode.Substring(8);
                        var removeSlipt = fvar.Replace(".", "") + "" + svar.Replace(".", "") + "" + tvar.Replace(".", "").Replace(".", "") + "" + lvar.Replace(".", "");

                        var jointHscode = await _context.HSCodePools.Include(x => x.Country).FirstOrDefaultAsync(x => x.Country.CountryName == GetCountry.CountryName && x.HSCode == removeSlipt, cancellationToken);
                        if (jointHscode != null)
                        {
                            #region Ghana Calculation
                            if (GetCountry.CountryCode == "GH")
                            {
                                var duty = await _generalGoodsService.GeneralGoodsTrialGhana(request.GuestCookie,NoSplithsCode.Id, NoSplithsCode.HSCode, request.FOB, request.Freight, request.Insurance, request.CurrencyId, GetCountry.Id, jointHscode.StandardUnitOfQuantity, request.ExportingCountryId, request.Keyword, request.ContainerSize, cancellationToken);
                                return duty;
                            }
                            #endregion

                            #region Nigeria Calculation
                            if (GetCountry.CountryCode == "NGN")
                            {
                                var duty = await _generalGoodsService.GeneralGoodsTrialNigeria(request.GuestCookie,jointHscode.Id, jointHscode.HSCode, request.FOB, request.Freight, request.Insurance, request.CurrencyId, GetCountry.Id, jointHscode.StandardUnitOfQuantity, request.ExportingCountryId, request.Keyword, request.ContainerSize, cancellationToken);
                                return duty;
                            }
                            #endregion
                            //else do for other countries
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
