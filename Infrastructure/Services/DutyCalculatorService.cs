using Application.Common.Helper;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Services
{
    public class DutyCalculatorService : IDutyCalculatorService
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
       // private readonly HsCodeSlipter _slipter;
     //  private readonly IDepreciationService _depreciationService;


        public DutyCalculatorService(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
          
         //  _depreciationService = depreciationService;

        }
        public async Task<CalculatedDuty>GhanaCalculation(VehicleFactory vehicleFactory, CancellationToken cancellationToken)
        {
            decimal percent;
            //  decimal num1;

            var GetCountry =  _context.Countries.Where(x => x.CountryName == "Ghana").FirstOrDefault();
            DutyCalculationsModel _dutyCalculationsModel = new DutyCalculationsModel();
            Depreciation _depreciationService = new Depreciation();
            var userId =  _currentUserService.GetUserId();
            decimal GetHDV = decimal.Parse(vehicleFactory.HDV.ToString());
            double DiscountRate = 0.3;

            decimal TotalHDV = GetHDV - (GetHDV * decimal.Parse(DiscountRate.ToString()));
            decimal GetEngineCapaity = decimal.Parse(vehicleFactory.EngineCapacity.ToString());

            #region exchange rate and Hscode pooling
            var exchangeRate = await _context.ExchangeRates.Where(x => x.Currency.Name == vehicleFactory.Currency).OrderByDescending(x => x.Week).FirstOrDefaultAsync();
            if(exchangeRate == null)
            {
                return null;
            }
            //var GetHscode = await _context.ClassifyHscodes.Where(x => x.Code == vehicleFactory.AssessedHSCode).FirstOrDefaultAsync();
            //if(GetHscode == null)
            //{
            //    return null;
            //}

            string eight = vehicleFactory.AssessedHSCode.Substring(0, 10);
            string seven = vehicleFactory.AssessedHSCode.Substring(0, 7);
            string four = vehicleFactory.AssessedHSCode.Substring(0, 4);
            var GetHscode = await _context.ClassifyHscodes.Where(x => x.Code == vehicleFactory.AssessedHSCode).FirstOrDefaultAsync();
            if (GetHscode == null)
            {
                var getsub = await _context.ClassifyHscodes.Where(x => x.Code.StartsWith(eight)).FirstOrDefaultAsync();
                if (getsub != null)
                {
                    GetHscode = getsub;
                }
                else
                {
                    var getsub7 = await _context.ClassifyHscodes.Where(x => x.Code.StartsWith(seven)).FirstOrDefaultAsync();
                    if (getsub7 != null)
                    {
                        GetHscode = getsub7;
                    }
                    else
                    {
                        var getsub4 = await _context.ClassifyHscodes.Where(x => x.Code.StartsWith(four)).FirstOrDefaultAsync();
                        GetHscode = getsub4;
                    }
                }
            }

            #endregion

            string str = " ";
            DateTime now = DateTime.Now;
            string str1 = "First";
            if (now.Month > 6)
            {
                str1 = "Second";
            }

            #region storing exchage rate and shipper rate before and after deduction

            _dutyCalculationsModel.rate = exchangeRate.Rate.ToString();
            _dutyCalculationsModel.rateafterdedution = exchangeRate.Rate.ToString();
            _dutyCalculationsModel.Hscodeafterdedution = vehicleFactory.AssessedHSCode;

            _dutyCalculationsModel.shppersafterdedution = "5.00";
            _dutyCalculationsModel.shppers = "5.00";
            _dutyCalculationsModel.Hscode = vehicleFactory.AssessedHSCode;

            #endregion

            var getCurreny = _context.Currencies.Where(x => x.Id == exchangeRate.CurrencyId).FirstOrDefault();
            if(getCurreny==null)
            {
                return null;
            }

            #region Overage validation

            int year = now.Year - int.Parse(vehicleFactory.ManufactureYear);

            var GetVehicleType = await _context.VehicleTypes.Where(x => x.Name == vehicleFactory.VehicleType).FirstOrDefaultAsync();
            if(GetVehicleType==null)
            {
                return null;
            }
            var GetCategory = await _context.VehicleCategories.Where(x => x.Id == GetVehicleType.VehicleCategoryId).FirstOrDefaultAsync();
            if(GetCategory ==null)
            {
                return null;
            }
            var GetOverAge = await _context.FreightOverages.Where(x => x.VehicleType.Name == vehicleFactory.VehicleType && (int?)year >= x.MinimumAge && (int?)year <= x.MaximumAge).OrderByDescending(x=>x.Id).FirstOrDefaultAsync();
            var FreightRateList = await _context.FreightRates.Where(x => x.VehicleCategoryId == GetCategory.Id).ToListAsync();
            if (FreightRateList.Count > 1)
            {
                FreightRateList = FreightRateList.Where(x => x.VehicleCategoryId == GetVehicleType.VehicleCategoryId && x.MinimumCC <= decimal.Parse(vehicleFactory.EngineCapacity) && x.MaximumCC >= decimal.Parse(vehicleFactory.EngineCapacity)).ToList();
            }

            FreightRate sidFreightRate = new FreightRate();
            if (FreightRateList.Count >= 1)
            {
                sidFreightRate = FreightRateList.FirstOrDefault<FreightRate>();
            }
            #endregion

            _dutyCalculationsModel.freight = GetOverAge.Rate.ToString();
            int numToDivide = 100;
            #region Getdepreciation before discount
            decimal Getdepreciation = _depreciationService.CalDepreciation(int.Parse(vehicleFactory.ManufactureYear), decimal.Parse(GetHDV.ToString()), str1);
            _dutyCalculationsModel.depreciation = Getdepreciation.ToString();
            #endregion

            #region Getdepreciation after discount
            decimal Totaldepreciation = _depreciationService.CalDepreciation(int.Parse(vehicleFactory.ManufactureYear), TotalHDV, str1);
            _dutyCalculationsModel.depreciationafterdedution = Totaldepreciation.ToString();
            decimal num10 = decimal.Parse(TotalHDV.ToString()) - Totaldepreciation;
            #endregion


            _dutyCalculationsModel.FOBafterdedution = num10;
            double insureanceValue = 0.875;
            decimal num12 = decimal.Parse(num10.ToString());

            GetHDV = decimal.Parse(GetOverAge.Rate.ToString());
            decimal num13 = (num12 + decimal.Parse(GetHDV.ToString())) * (decimal.Parse(insureanceValue.ToString()) / numToDivide);

            _dutyCalculationsModel.insuranceafterdedution = decimal.Parse(num13.ToString("N"));
            decimal num14 = decimal.Parse(num13.ToString());

            decimal num15 = decimal.Parse(GetHDV.ToString());
            decimal num16 = (num10 + num14) + num15;


            _dutyCalculationsModel.cifafterdedution = string.Concat(num16.ToString("N"), str, getCurreny.Name);
            string str2 = "CEDI";
            decimal rate = exchangeRate.Rate;
            decimal num17 = decimal.Parse(rate.ToString());
            decimal num18 = num16 * num17;
            decimal num19 = Math.Round(num18, 2);

            _dutyCalculationsModel.ghcedisafterdedution = string.Concat(str2, str, num19.ToString("N"));
            decimal? importduty = decimal.Parse("5.0");
            GetHDV = GetHscode.ImportDuty;

            decimal num21 = (decimal.Parse(GetHDV.ToString()) / numToDivide) * num18;
            _dutyCalculationsModel.Importdutyafterdedution = num21.ToString("N");
            string str3 = "0.01";
            if (num21 <= decimal.Zero)
            {
                percent = num18 * decimal.Parse(str3);
                _dutyCalculationsModel.ProcessingFeeafterdedution = percent.ToString("N");
            }
            else
            {
                percent = new decimal();
                _dutyCalculationsModel.ProcessingFeeafterdedution = percent.ToString("N");
            }

            //vat and nhil after discount
            decimal num22 = (new decimal(15) / numToDivide) * (num18 + num21);
            _dutyCalculationsModel.vatafterdedution = num22.ToString("N");
            GetHDV = GetHscode.NHIL;
            decimal num23 = (decimal.Parse(GetHDV.ToString()) / numToDivide) * (num18 + num21);
            _dutyCalculationsModel.nhilafterdedution = num23.ToString("N");

            //interest charges and ecowas after deduction
            decimal num24 = (num21 + num22) / 48;
            _dutyCalculationsModel.interestChargeafterdedution = num24.ToString("N");

            string str4 = "0.75";
            decimal num25 = (num18 * decimal.Parse(str4)) / numToDivide;
            _dutyCalculationsModel.ecowasafterdedution = num25.ToString("N");

            //network charges after discount
            decimal num26 = decimal.Parse(num10.ToString());
            rate = exchangeRate.Rate;
            decimal num27 = num26 * decimal.Parse(rate.ToString());
            decimal num28 = (decimal.Parse("0.4") / numToDivide) * num27;
            _dutyCalculationsModel.networkChargeafterdedution = num28.ToString("N");

            //edif after discount
            decimal num29 = (num18 * decimal.Parse(str4)) / numToDivide;
            _dutyCalculationsModel.edifafterdedution = num29.ToString("N");
            decimal num30 = num28 * (new decimal(15) / numToDivide);

            //net charge vat after discount
            _dutyCalculationsModel.NetchargeVatafterdedution = num30.ToString("N");
            decimal num31 = num18 * decimal.Parse(str3);

            //exam fee after discount
            _dutyCalculationsModel.examfeeafterdedution = num31.ToString("N");
            string str5 = "2.5";
            decimal num32 = num28 * (decimal.Parse(str5) / numToDivide);

            //net charge nhil after discount
            _dutyCalculationsModel.NetchargeNhilafterdedution = num32.ToString("N");
            string str6 = "2.0";
            decimal num33 = num18 * (decimal.Parse(str6) / numToDivide);

            //speacial leavy after discount
            _dutyCalculationsModel.specialLevyafterdedutiony = num33.ToString("N");
            GetHDV = GetOverAge.OverAgeRate;
            decimal num34 = num18 * (decimal.Parse(GetHDV.ToString()) / numToDivide);

            //overage after discount
            _dutyCalculationsModel.Overageafterdedution = num34.ToString("N");
            decimal num35 = new decimal(5);

            //total in local currency after discount
            decimal num36 = (num21 + num22 + num23 + num25 + num29 + num34 + num31 + num24 + num33 + percent + num28 + num30 + num32) + num35;
            _dutyCalculationsModel.localCurrencyafterdedution = num36.ToString("N");



            decimal num37 = Getdepreciation - decimal.Parse(GetHDV.ToString());
            _dutyCalculationsModel.FOB = num37;
            double num38 = 0.875;
            decimal num39 = decimal.Parse(num37.ToString());

            GetHDV = GetOverAge.Rate;
            decimal num40 = (num39 + decimal.Parse(GetHDV.ToString())) * (decimal.Parse(num38.ToString()) / numToDivide);
            _dutyCalculationsModel.insurance = decimal.Parse(num40.ToString("N"));
            decimal num41 = decimal.Parse(num40.ToString());
            GetHDV = GetOverAge.Rate;
            decimal num42 = decimal.Parse(GetHDV.ToString());
            decimal num43 = (num37 + num41) + num42;
            _dutyCalculationsModel.cif = string.Concat(num43.ToString("N"));

            string str7 = "CEDI";
            rate = exchangeRate.Rate;
            decimal num44 = decimal.Parse(rate.ToString());
            decimal num45 = num43 * num44;
            decimal num46 = Math.Round(num45, 2);
            _dutyCalculationsModel.ghcedis = string.Concat(str7, str, num46.ToString("N"));
            GetHDV = GetHscode.ImportDuty;
            decimal num47 = decimal.Parse(GetHDV.ToString());
            decimal num48 = (decimal.Parse(num47.ToString()) / numToDivide) * num45;
            _dutyCalculationsModel.Importduty = num48.ToString("N");
            string str8 = "0.01";

            if (num48 <= decimal.Zero)
            {
                percent = num45 * decimal.Parse(str8);
                _dutyCalculationsModel.ProcessingFee = percent.ToString("N");
            }
            else
            {
                percent = new decimal();
                _dutyCalculationsModel.ProcessingFee = percent.ToString("N");
            }


            decimal num49 = (new decimal(15) / numToDivide) * (num45 + num48);
            _dutyCalculationsModel.vat = num49.ToString("N");
            GetHDV = GetHscode.NHIL;
            decimal num50 = (decimal.Parse(GetHDV.ToString()) / numToDivide) * (num45 + num48);
            _dutyCalculationsModel.nhil = num50.ToString("N");

            decimal num51 = (num48 + num49) / 48;
            _dutyCalculationsModel.interestCharge = num51.ToString("N");

            string str9 = "0.75";
            decimal num52 = (num45 * decimal.Parse(str9)) / numToDivide;
            _dutyCalculationsModel.ecowas = num52.ToString("N");

            decimal num53 = decimal.Parse(num37.ToString());
            rate = exchangeRate.Rate;
            decimal num54 = num53 * decimal.Parse(rate.ToString());
            decimal num55 = (decimal.Parse("0.4") / numToDivide) * num54;
            _dutyCalculationsModel.networkCharge = num55.ToString("N");


            decimal num56 = (num45 * decimal.Parse(str9)) / numToDivide;
            _dutyCalculationsModel.edif = num56.ToString("N");

            decimal num57 = num55 * (new decimal(15) / numToDivide);
            _dutyCalculationsModel.NetchargeVat = num57.ToString("N");

            decimal num58 = num45 * decimal.Parse(str8);
            _dutyCalculationsModel.examfee = num58.ToString("N");

            string str10 = "2.5";
            decimal num59 = num55 * (decimal.Parse(str10) / numToDivide);
            _dutyCalculationsModel.NetchargeNhil = num59.ToString("N");

            string str11 = "2.0";
            decimal num60 = num45 * (decimal.Parse(str11) / numToDivide);
            _dutyCalculationsModel.specialLevy = num60.ToString("N");

            GetHDV = GetOverAge.OverAgeRate;
            decimal num61 = num45 * (decimal.Parse(GetHDV.ToString()) / numToDivide);
            _dutyCalculationsModel.Overage = num61.ToString("N");

            decimal shippers = new decimal(5.0);
            decimal TotalTransactionCurrency = (num48 + num49 + num50 + num52 + num56 + num61 + num58 + num51 + num60 + percent + num55 + num57 + num59) + shippers;
            _dutyCalculationsModel.localCurrency = TotalTransactionCurrency.ToString("N");

            #region store calculated result
            var entity = new CalculatedDuty
            {
                VehicleType = vehicleFactory.VehicleType,
                VehicleMake = vehicleFactory.MakeName,
                VehicleModel = vehicleFactory.ModelName,
                ChassisNo = vehicleFactory.ChassisNo,
                YearOfManufacture = vehicleFactory.ManufactureYear,
                HDV = vehicleFactory.HDV,
                CC = vehicleFactory.EngineCapacity,
                DepreciationAllow = decimal.Parse(_dutyCalculationsModel.depreciation),
                FOB = _dutyCalculationsModel.FOB,
                Freight = decimal.Parse(_dutyCalculationsModel.freight),
                Insurance = _dutyCalculationsModel.insurance,
                CIFForginCurrency = decimal.Parse(_dutyCalculationsModel.cif),
                CurrencyName = getCurreny.Name,
                ExchangeRate = exchangeRate.Rate,
                CIFLocalCurrency = decimal.Parse(_dutyCalculationsModel.localCurrency),
                HsCode = vehicleFactory.AssessedHSCode,
                ImportDuty = decimal.Parse(_dutyCalculationsModel.Importduty),
                ProcessingFee = decimal.Parse(_dutyCalculationsModel.ProcessingFee),
                VAT = decimal.Parse(_dutyCalculationsModel.vat),
                Shipper = decimal.Parse(_dutyCalculationsModel.shppers),
                NHIL = decimal.Parse(_dutyCalculationsModel.nhil),
                InterestCharge = decimal.Parse(_dutyCalculationsModel.interestCharge),
                Ecowas = decimal.Parse(_dutyCalculationsModel.ecowas),
                NetworkCharge = decimal.Parse(_dutyCalculationsModel.networkCharge),
                EXIM = decimal.Parse(_dutyCalculationsModel.edif),
                NetChargeVAT = decimal.Parse(_dutyCalculationsModel.NetchargeVat),
                ExamFee = decimal.Parse(_dutyCalculationsModel.examfee),
                NetChargeNHIL = decimal.Parse(_dutyCalculationsModel.NetchargeNhil),
                SpecialImpLevy = decimal.Parse(_dutyCalculationsModel.specialLevy),
                OverAgePenalty = decimal.Parse(_dutyCalculationsModel.Overage),
                TotalDutyAfterDeduction = decimal.Parse(_dutyCalculationsModel.localCurrencyafterdedution),
                TotalDutyBeforeDeduction = decimal.Parse(_dutyCalculationsModel.localCurrency),
                TransactionDate = DateTime.Now,
                UserId = userId,
                TransactionId = Guid.NewGuid(),
                SpecialFeatures = vehicleFactory.SpecialFeatures,
                NoOfDoors = vehicleFactory.NoOfDoors,
                SeatingCapacity = vehicleFactory.SeatingCapacity,
                FuelType = vehicleFactory.FuelType,
                Color = vehicleFactory.Colour,
                CountryId = GetCountry.Id
            };
            #endregion

            _context.CalculatedDuties.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<CalculatedDuty> GhanaCalculateFromPool(VehicleSearchPool vehicleSearchPool, CancellationToken cancellationToken)
        {
            var GetCountry = _context.Countries.Where(x => x.CountryName == "Ghana").FirstOrDefault();
            decimal percent;            
            DutyCalculationsModel _dutyCalculationsModel = new DutyCalculationsModel();
            Depreciation _depreciationService = new Depreciation();
            var userId = _currentUserService.GetUserId();
            decimal GetHDV = decimal.Parse(vehicleSearchPool.HDV.ToString());
            double DiscountRate = 0.3;

            decimal TotalHDV = GetHDV - (GetHDV * decimal.Parse(DiscountRate.ToString()));
            decimal GetEngineCapaity = decimal.Parse(vehicleSearchPool.EngineCapacity.ToString());

            #region exchange rate and Hscode pooling
            var exchangeRate = await _context.ExchangeRates.Where(x => x.Currency.Name == vehicleSearchPool.CurrencyName).OrderByDescending(x => x.Week).FirstOrDefaultAsync();
            if (exchangeRate == null)
            {
                return null;
            }

            
            string eight = vehicleSearchPool.AssessedHSCode.Substring(0, 10);
            string seven = vehicleSearchPool.AssessedHSCode.Substring(0, 7);
            string four = vehicleSearchPool.AssessedHSCode.Substring(0, 4);
            var GetHscode = await _context.ClassifyHscodes.Where(x => x.Code==vehicleSearchPool.AssessedHSCode).FirstOrDefaultAsync();
            if (GetHscode == null)
            {
                var getsub = await _context.ClassifyHscodes.Where(x => x.Code.StartsWith(eight)).FirstOrDefaultAsync();
                if(getsub !=null)
                {
                    GetHscode = getsub;
                }
                else
                {
                    var getsub7 = await _context.ClassifyHscodes.Where(x => x.Code.StartsWith(seven)).FirstOrDefaultAsync();
                    if(getsub7 != null)
                    {
                        GetHscode = getsub7;
                    }
                    else
                    {
                        var getsub4 = await _context.ClassifyHscodes.Where(x => x.Code.StartsWith(four)).FirstOrDefaultAsync();
                        GetHscode = getsub4;
                    }
                }
            }

            #endregion

            string str = " ";
            DateTime now = DateTime.Now;
            string str1 = "First";
            if (now.Month > 6)
            {
                str1 = "Second";
            }


            #region storing exchage rate and shipper rate before and after deduction

            _dutyCalculationsModel.rate = exchangeRate.Rate.ToString();
            _dutyCalculationsModel.rateafterdedution = exchangeRate.Rate.ToString();
            _dutyCalculationsModel.Hscodeafterdedution = vehicleSearchPool.AssessedHSCode;

            _dutyCalculationsModel.shppersafterdedution = "5.00";
            _dutyCalculationsModel.shppers = "5.00";
            _dutyCalculationsModel.Hscode = vehicleSearchPool.AssessedHSCode;

            #endregion

            var getCurreny = _context.Currencies.Where(x => x.Id == exchangeRate.CurrencyId).FirstOrDefault();
            if (getCurreny == null)
            {
                return null;
            }


            #region Overage validation

            int year = now.Year - vehicleSearchPool.Year;

            var GetVehicleType = await _context.VehicleTypes.Where(x => x.Name == vehicleSearchPool.VehicleTypeName).FirstOrDefaultAsync();
            if (GetVehicleType == null)
            {
                return null;
            }
            var GetCategory = await _context.VehicleCategories.Where(x => x.Id == GetVehicleType.VehicleCategoryId).FirstOrDefaultAsync();
            if (GetCategory == null)
            {
                return null;
            }
            var GetOverAge = await _context.FreightOverages.Where(x => x.VehicleType.Name == vehicleSearchPool.VehicleTypeName && (int?)year >= x.MinimumAge && (int?)year <= x.MaximumAge).OrderByDescending(x=>x.Id).FirstOrDefaultAsync();
            var FreightRateList = await _context.FreightRates.Where(x => x.VehicleCategoryId == GetCategory.Id).ToListAsync();
            if (FreightRateList.Count > 1)
            {
                FreightRateList = FreightRateList.Where(x => x.VehicleCategoryId == GetVehicleType.VehicleCategoryId && x.MinimumCC <= decimal.Parse(vehicleSearchPool.EngineCapacity) && x.MaximumCC >= decimal.Parse(vehicleSearchPool.EngineCapacity)).ToList();
            }

            FreightRate sidFreightRate = new FreightRate();
            if (FreightRateList.Count >= 1)
            {
                sidFreightRate = FreightRateList.FirstOrDefault<FreightRate>();
            }
            #endregion

            _dutyCalculationsModel.freight = GetOverAge.Rate.ToString();
            int numToDivide = 100;
            #region Getdepreciation before discount
            decimal Getdepreciation = _depreciationService.CalDepreciation(vehicleSearchPool.Year, decimal.Parse(GetHDV.ToString()), str1);
            _dutyCalculationsModel.depreciation = Getdepreciation.ToString();
            #endregion

            #region Getdepreciation after discount
            decimal Totaldepreciation = _depreciationService.CalDepreciation(vehicleSearchPool.Year, decimal.Parse(GetHDV.ToString()), str1);
            _dutyCalculationsModel.depreciationafterdedution = Totaldepreciation.ToString();
            decimal num10 = decimal.Parse(TotalHDV.ToString()) - Totaldepreciation;
            #endregion


            _dutyCalculationsModel.FOBafterdedution = num10;
            double insureanceValue = 0.875;
            decimal num12 = decimal.Parse(num10.ToString());

            GetHDV = decimal.Parse(GetOverAge.Rate.ToString());
            decimal num13 = (num12 + decimal.Parse(GetHDV.ToString())) * (decimal.Parse(insureanceValue.ToString()) / numToDivide);

            _dutyCalculationsModel.insuranceafterdedution = decimal.Parse(num13.ToString("N"));
            decimal num14 = decimal.Parse(num13.ToString());

            decimal num15 = decimal.Parse(GetHDV.ToString());
            decimal num16 = (num10 + num14) + num15;


            _dutyCalculationsModel.cifafterdedution = string.Concat(num16.ToString("N"), str, getCurreny.Name);
            string str2 = "CEDI";
            decimal rate = exchangeRate.Rate;
            decimal num17 = decimal.Parse(rate.ToString());
            decimal num18 = num16 * num17;
            decimal num19 = Math.Round(num18, 2);

            _dutyCalculationsModel.ghcedisafterdedution = string.Concat(str2, str, num19.ToString("N"));
            decimal? importduty = decimal.Parse("5.0");
            GetHDV = GetHscode.ImportDuty;

            decimal num21 = (decimal.Parse(GetHDV.ToString()) / numToDivide) * num18;
            _dutyCalculationsModel.Importdutyafterdedution = num21.ToString("N");
            string str3 = "0.01";
            if (num21 <= decimal.Zero)
            {
                percent = num18 * decimal.Parse(str3);
                _dutyCalculationsModel.ProcessingFeeafterdedution = percent.ToString("N");
            }
            else
            {
                percent = new decimal();
                _dutyCalculationsModel.ProcessingFeeafterdedution = percent.ToString("N");
            }

            //vat and nhil after discount
            decimal num22 = (new decimal(15) / numToDivide) * (num18 + num21);
            _dutyCalculationsModel.vatafterdedution = num22.ToString("N");
            GetHDV = GetHscode.NHIL;
            decimal num23 = (decimal.Parse(GetHDV.ToString()) / numToDivide) * (num18 + num21);
            _dutyCalculationsModel.nhilafterdedution = num23.ToString("N");

            //interest charges and ecowas after deduction
            decimal num24 = (num21 + num22) / 48;
            _dutyCalculationsModel.interestChargeafterdedution = num24.ToString("N");

            string str4 = "0.75";
            decimal num25 = (num18 * decimal.Parse(str4)) / numToDivide;
            _dutyCalculationsModel.ecowasafterdedution = num25.ToString("N");

            //network charges after discount
            decimal num26 = decimal.Parse(num10.ToString());
            rate = exchangeRate.Rate;
            decimal num27 = num26 * decimal.Parse(rate.ToString());
            decimal num28 = (decimal.Parse("0.4") / numToDivide) * num27;
            _dutyCalculationsModel.networkChargeafterdedution = num28.ToString("N");

            //edif after discount
            decimal num29 = (num18 * decimal.Parse(str4)) / numToDivide;
            _dutyCalculationsModel.edifafterdedution = num29.ToString("N");
            decimal num30 = num28 * (new decimal(15) / numToDivide);

            //net charge vat after discount
            _dutyCalculationsModel.NetchargeVatafterdedution = num30.ToString("N");
            decimal num31 = num18 * decimal.Parse(str3);

            //exam fee after discount
            _dutyCalculationsModel.examfeeafterdedution = num31.ToString("N");
            string str5 = "2.5";
            decimal num32 = num28 * (decimal.Parse(str5) / numToDivide);

            //net charge nhil after discount
            _dutyCalculationsModel.NetchargeNhilafterdedution = num32.ToString("N");
            string str6 = "2.0";
            decimal num33 = num18 * (decimal.Parse(str6) / numToDivide);

            //speacial leavy after discount
            _dutyCalculationsModel.specialLevyafterdedutiony = num33.ToString("N");
            GetHDV = GetOverAge.OverAgeRate;
            decimal num34 = num18 * (decimal.Parse(GetHDV.ToString()) / numToDivide);

            //overage after discount
            _dutyCalculationsModel.Overageafterdedution = num34.ToString("N");
            decimal num35 = new decimal(5);

            //total in local currency after discount
            decimal num36 = (num21 + num22 + num23 + num25 + num29 + num34 + num31 + num24 + num33 + percent + num28 + num30 + num32) + num35;
            _dutyCalculationsModel.localCurrencyafterdedution = num36.ToString("N");



            decimal num37 = Getdepreciation - decimal.Parse(GetHDV.ToString());
            _dutyCalculationsModel.FOB = num37;
            double num38 = 0.875;
            decimal num39 = decimal.Parse(num37.ToString());

            GetHDV = GetOverAge.Rate;
            decimal num40 = (num39 + decimal.Parse(GetHDV.ToString())) * (decimal.Parse(num38.ToString()) / numToDivide);
            _dutyCalculationsModel.insurance = decimal.Parse(num40.ToString("N"));
            decimal num41 = decimal.Parse(num40.ToString());
            GetHDV = GetOverAge.Rate;
            decimal num42 = decimal.Parse(GetHDV.ToString());
            decimal num43 = (num37 + num41) + num42;
            _dutyCalculationsModel.cif = string.Concat(num43.ToString("N"));

            string str7 = "CEDI";
            rate = exchangeRate.Rate;
            decimal num44 = decimal.Parse(rate.ToString());
            decimal num45 = num43 * num44;
            decimal num46 = Math.Round(num45, 2);
            _dutyCalculationsModel.ghcedis = string.Concat(str7, str, num46.ToString("N"));
            GetHDV = GetHscode.ImportDuty;
            decimal num47 = decimal.Parse(GetHDV.ToString());
            decimal num48 = (decimal.Parse(num47.ToString()) / numToDivide) * num45;
            _dutyCalculationsModel.Importduty = num48.ToString("N");
            string str8 = "0.01";

            if (num48 <= decimal.Zero)
            {
                percent = num45 * decimal.Parse(str8);
                _dutyCalculationsModel.ProcessingFee = percent.ToString("N");
            }
            else
            {
                percent = new decimal();
                _dutyCalculationsModel.ProcessingFee = percent.ToString("N");
            }


            decimal num49 = (new decimal(15) / numToDivide) * (num45 + num48);
            _dutyCalculationsModel.vat = num49.ToString("N");
            GetHDV = GetHscode.NHIL;
            decimal num50 = (decimal.Parse(GetHDV.ToString()) / numToDivide) * (num45 + num48);
            _dutyCalculationsModel.nhil = num50.ToString("N");

            decimal num51 = (num48 + num49) / 48;
            _dutyCalculationsModel.interestCharge = num51.ToString("N");

            string str9 = "0.75";
            decimal num52 = (num45 * decimal.Parse(str9)) / numToDivide;
            _dutyCalculationsModel.ecowas = num52.ToString("N");

            decimal num53 = decimal.Parse(num37.ToString());
            rate = exchangeRate.Rate;
            decimal num54 = num53 * decimal.Parse(rate.ToString());
            decimal num55 = (decimal.Parse("0.4") / numToDivide) * num54;
            _dutyCalculationsModel.networkCharge = num55.ToString("N");


            decimal num56 = (num45 * decimal.Parse(str9)) / numToDivide;
            _dutyCalculationsModel.edif = num56.ToString("N");

            decimal num57 = num55 * (new decimal(15) / numToDivide);
            _dutyCalculationsModel.NetchargeVat = num57.ToString("N");

            decimal num58 = num45 * decimal.Parse(str8);
            _dutyCalculationsModel.examfee = num58.ToString("N");

            string str10 = "2.5";
            decimal num59 = num55 * (decimal.Parse(str10) / numToDivide);
            _dutyCalculationsModel.NetchargeNhil = num59.ToString("N");

            string str11 = "2.0";
            decimal num60 = num45 * (decimal.Parse(str11) / numToDivide);
            _dutyCalculationsModel.specialLevy = num60.ToString("N");

            GetHDV = GetOverAge.OverAgeRate;
            decimal num61 = num45 * (decimal.Parse(GetHDV.ToString()) / numToDivide);
            _dutyCalculationsModel.Overage = num61.ToString("N");

            decimal shippers = new decimal(5.0);
            decimal TotalTransactionCurrency = (num48 + num49 + num50 + num52 + num56 + num61 + num58 + num51 + num60 + percent + num55 + num57 + num59) + shippers;
            _dutyCalculationsModel.localCurrency = TotalTransactionCurrency.ToString("N");


            #region store calculated result
            var entity = new CalculatedDuty
            {
                VehicleType = vehicleSearchPool.VehicleTypeName,
                VehicleMake = vehicleSearchPool.MakeName,
                VehicleModel = vehicleSearchPool.ModelName,
                ChassisNo = vehicleSearchPool.ChassisNo,
                YearOfManufacture = vehicleSearchPool.Year.ToString(),
                HDV = decimal.Parse(vehicleSearchPool.HDV.ToString()),
                CC = vehicleSearchPool.EngineCapacity,
                DepreciationAllow = decimal.Parse(_dutyCalculationsModel.depreciation),
                FOB = _dutyCalculationsModel.FOB,
                Freight = decimal.Parse(_dutyCalculationsModel.freight),
                Insurance = _dutyCalculationsModel.insurance,
                CIFForginCurrency = decimal.Parse(_dutyCalculationsModel.cif),
                CurrencyName = getCurreny.Name,
                ExchangeRate = exchangeRate.Rate,
                CIFLocalCurrency = decimal.Parse(_dutyCalculationsModel.localCurrency),
                HsCode = vehicleSearchPool.AssessedHSCode,
                ImportDuty = decimal.Parse(_dutyCalculationsModel.Importduty),
                ProcessingFee = decimal.Parse(_dutyCalculationsModel.ProcessingFee),
                VAT = decimal.Parse(_dutyCalculationsModel.vat),
                Shipper = decimal.Parse(_dutyCalculationsModel.shppers),
                NHIL = decimal.Parse(_dutyCalculationsModel.nhil),
                InterestCharge = decimal.Parse(_dutyCalculationsModel.interestCharge),
                Ecowas = decimal.Parse(_dutyCalculationsModel.ecowas),
                NetworkCharge = decimal.Parse(_dutyCalculationsModel.networkCharge),
                EXIM = decimal.Parse(_dutyCalculationsModel.edif),
                NetChargeVAT = decimal.Parse(_dutyCalculationsModel.NetchargeVat),
                ExamFee = decimal.Parse(_dutyCalculationsModel.examfee),
                NetChargeNHIL = decimal.Parse(_dutyCalculationsModel.NetchargeNhil),
                SpecialImpLevy = decimal.Parse(_dutyCalculationsModel.specialLevy),
                OverAgePenalty = decimal.Parse(_dutyCalculationsModel.Overage),
                TotalDutyAfterDeduction = decimal.Parse(_dutyCalculationsModel.localCurrencyafterdedution),
                TotalDutyBeforeDeduction = decimal.Parse(_dutyCalculationsModel.localCurrency),
                TransactionDate = DateTime.Now,
                UserId = vehicleSearchPool.UserId,
                TransactionId = vehicleSearchPool.TransactionId,
                SpecialFeatures = vehicleSearchPool.SpecialFeatureName,
                NoOfDoors = vehicleSearchPool.NoOfDoor,
                SeatingCapacity = vehicleSearchPool.SeatingCapacity,
                FuelType = vehicleSearchPool.FuelType,
                Color = "Black",
                CountryId = GetCountry.Id
            };
            #endregion

            _context.CalculatedDuties.Add(entity);

            var pool = await _context.VehicleSearchPools.Where(x => x.TransactionId == entity.TransactionId).FirstOrDefaultAsync();
            pool.Status = "Duty Calculated";
            await _context.SaveChangesAsync(cancellationToken);

            return entity;


        }


      
    }
}
