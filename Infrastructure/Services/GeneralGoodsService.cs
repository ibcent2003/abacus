using Application.Common.Helper;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.GeneralGoods.Query;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Services
{
    public class GeneralGoodsService : IGeneralGoodsService
    {        
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;       
       // private readonly IMapper _mapper;

        public GeneralGoodsService(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
           // _mapper = mapper;         
        }

        public async Task<UserHSCodePool> GeneralGoodsCalculationGhana(int Id, string hsCode, decimal Fob, decimal freight, decimal insurance, int currencyId, int countryId, string StandardUnitOfQuantity, int exportingCountryId, string keyword, string containerSize, CancellationToken cancellationToken)

        {
            try
            {
                var exchangeRate = await _context.ExchangeRates.Where(x => x.CurrencyId == currencyId && x.CountryId==countryId).OrderByDescending(x => x.Week).FirstOrDefaultAsync();               
              
                decimal ProductValue = Fob;
              
                decimal TotalCIF = (ProductValue + freight) + insurance;

                #region store user hs code pool               
                UserHSCodePool userhscode = new UserHSCodePool
                {
                    HsCode = hsCode,
                    FOB = Fob,
                    Freight = freight,
                    Insurance = insurance,
                    CurrencyId = currencyId,
                    CountryId = countryId,
                    UserId = _currentUserService.GetUserId(),
                    TransactionDate = DateTime.Now,
                    TransactionId = Guid.NewGuid(),
                    StandardUnitOfQuantity = StandardUnitOfQuantity,
                    ExportingCountryId = exportingCountryId,
                    Keyword = keyword,
                    ContainerSize = containerSize

                };
                _context.UserHSCodePools.Add(userhscode);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region Taxes are here
                var getImportDuty = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 1 && x.HsCodePoolId == Id);
                var getImportVat = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 2 && x.HsCodePoolId == Id);
                var getImportNHIL = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 3 && x.HsCodePoolId == Id);
                var getImportExcise = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 4 && x.HsCodePoolId == Id);
                var getAfricanUnionImportlevy = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 5 && x.HsCodePoolId == Id);
                var getCasseteLevy = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 6 && x.HsCodePoolId == Id);
                var getTotalEnivronmentalExcise = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 7 && x.HsCodePoolId ==Id);
                var getProcessfee = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 8 && x.HsCodePoolId == Id);
                var getImportLevy = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 9 && x.HsCodePoolId == Id);
                var getFund = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 10 && x.HsCodePoolId ==Id);
                #endregion

            
                #region store import duty
                UserTariffExtraTax importduty = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName ="Import Duty",
                    TaxValue = getImportDuty.TariffValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getImportDuty.IsRate
                };
                _context.UserTariffExtraTaxes.Add(importduty);
                await _context.SaveChangesAsync(cancellationToken);

                #endregion

                #region store import vat
                UserTariffExtraTax importvat = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Import Vat",
                    TaxValue = getImportVat.TariffValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getImportVat.IsRate,
                };
                _context.UserTariffExtraTaxes.Add(importvat);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region store import nhil
                UserTariffExtraTax importnhil = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Import NHIL",
                    TaxValue = getImportNHIL.TariffValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getImportNHIL.IsRate,
                };
                _context.UserTariffExtraTaxes.Add(importnhil);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region store fob
                UserTariffExtraTax fob = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Item FOB",
                    TaxValue = ProductValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(fob);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region store CIF
                UserTariffExtraTax cif = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "CIF",
                    TaxValue = TotalCIF,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(cif);
               await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region store rate
                UserTariffExtraTax rate = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Exchange Rate",
                    TaxValue = exchangeRate.Rate,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(rate);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion



                #region Calculated Taxes
                //Total Import duty Payble
                decimal DutyPayable = (TotalCIF * getImportDuty.TariffValue) / 100;

                //Total Get Fund
                decimal TotalGetFund = ((TotalCIF + DutyPayable + getImportExcise.TariffValue) * (getFund.TariffValue / 100));
                #region store get fund
                UserTariffExtraTax fund = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Get Fund",
                    TaxValue = TotalGetFund,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(fund);
               await _context.SaveChangesAsync(cancellationToken);
                #endregion



                //Total Processing Fees
                decimal TotalProcessingFee = (getProcessfee.TariffValue / 100) * TotalGetFund;
                #region //Insert Processing Fees
                //UserTariff userTariffProcessing = new UserTariff
                //{
                //    HsCodePoolId = Id,
                //    HSCodeTariffTaxId = getProcessfee.Id,
                //    TariffValue = getProcessfee.TariffValue,
                //    IsRate = getProcessfee.IsRate,
                //    UserId = _currentUserService.GetUserId(),
                //    TransactionId = userhscode.TransactionId
                //};
                //_context.UserTariffs.Add(userTariffProcessing);
                //await _context.SaveChangesAsync(cancellationToken);
                #endregion



                //Total Ecowas Leve 
                decimal TotalEcowasLevy = new decimal(5, 0, 0, false, 3)* TotalCIF;
                #region store Ecowas Levy
                UserTariffExtraTax EcowasLevy = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Ecowas Levy",
                    TaxValue = TotalEcowasLevy,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(EcowasLevy);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total casseteLevy
                decimal TotalCasseteLevy = (getCasseteLevy.TariffValue / 100) * TotalCIF;
                #region store Cassete Levy
                UserTariffExtraTax CasseteLevy = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Cassete Levy",//getCasseteLevy.HSCodeTariffTax.TaxName,
                    TaxValue = TotalCasseteLevy,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getCasseteLevy.IsRate
                };
                _context.UserTariffExtraTaxes.Add(CasseteLevy);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total Customs Inspection 
                decimal TotalCustomsInspection = new decimal(1, 0, 0, false, 2) * TotalCIF;
                #region store Customs Inspection
                UserTariffExtraTax Inspection = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Customs Inspection Fee",
                    TaxValue = TotalCustomsInspection,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(Inspection);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total IRSTaxDeposit
                decimal TotalIRSTaxDeposit = new decimal(1, 0, 0, false, 2) * TotalCIF;
                #region store IRSTaxDeposit
                UserTariffExtraTax IRSTaxDeposit = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "IRS Tax Deposit",
                    TaxValue = TotalIRSTaxDeposit,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(IRSTaxDeposit);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total ImportLevey
                decimal TotalImportLevey = (getImportLevy.TariffValue / 100) * TotalCIF;
                #region store Import Levy
                UserTariffExtraTax ImportLevy = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Import Levy",//getImportLevy.HSCodeTariffTax.TaxName,
                    TaxValue = TotalImportLevey,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(ImportLevy);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion



                //Total EnivronmentalExcise
                decimal TotalEnivronmentalExcise = (getTotalEnivronmentalExcise.TariffValue / 100) * TotalCIF;
                #region store Enivronmental Excise
                UserTariffExtraTax Excise = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Enivronmental Excise", //getTotalEnivronmentalExcise.HSCodeTariffTax.TaxName,
                    TaxValue = TotalEnivronmentalExcise,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getTotalEnivronmentalExcise.IsRate
                };
                _context.UserTariffExtraTaxes.Add(Excise);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total SIL 
                decimal TotalSIL = new decimal(2, 0, 0, false, 2) * TotalCIF;
                #region store Speacial Import Levy
                UserTariffExtraTax Speacial = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Special Import Levy",
                    TaxValue = TotalSIL,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(Speacial);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion


                //Total EXIM              
                decimal TotalEXIM = new decimal(75, 0, 0, false, 4) * TotalCIF;
                #region store EXIM
                UserTariffExtraTax EXIM = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "EXIM",
                    TaxValue = TotalEXIM,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(EXIM);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total africanUnionImportlevy
                decimal totalafricanUnionImportlevy = (getAfricanUnionImportlevy.TariffValue / 100);
                #region store african union
                UserTariffExtraTax africanUnionImportlevy = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "African Union Import Levy",//getAfricanUnionImportlevy.HSCodeTariffTax.TaxName,
                    TaxValue = totalafricanUnionImportlevy,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getAfricanUnionImportlevy.IsRate
                };
                _context.UserTariffExtraTaxes.Add(africanUnionImportlevy);
               await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total Duty Payable (Import Duty)                   
                decimal TotalImporttExcise = (getImportExcise.TariffValue * exchangeRate.Rate);
              

                //Total african union
                decimal TotalAfricanUnion = TotalImporttExcise;

                #region store Total Duty Payble
                UserTariffExtraTax TotalDutyPayble = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Duty Payable (Import Duty)",
                    TaxValue = DutyPayable,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(TotalDutyPayble);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total NHILPayble
                decimal TotalNHILPayble = ((TotalCIF + DutyPayable) + getImportExcise.TariffValue) * (getImportNHIL.TariffValue / 100);
                #region store NHIL Payble
                UserTariffExtraTax NHILPayble = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "NHIL Payable",
                    TaxValue = TotalNHILPayble,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false,
                };
                _context.UserTariffExtraTaxes.Add(NHILPayble);
               await _context.SaveChangesAsync(cancellationToken);
                #endregion
               


                //Total VatPayable
                decimal TotalVatpayable = Math.Round(TotalCIF + DutyPayable + getImportExcise.TariffValue + TotalGetFund + TotalNHILPayble + TotalAfricanUnion + TotalEXIM + TotalSIL + TotalEnivronmentalExcise + TotalImportLevey + TotalIRSTaxDeposit + TotalCustomsInspection + TotalCasseteLevy + TotalEcowasLevy + TotalProcessingFee * (getImportVat.TariffValue / 100),2);
                #region store VAT Payble
                UserTariffExtraTax VatPayble = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "VAT Payable",
                    TaxValue = TotalVatpayable,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(VatPayble);
               await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total Sub Duty Payable & Total Duty Payable
                decimal TotalSubDutyPayable =Math.Round((DutyPayable + TotalVatpayable) + TotalNHILPayble, 2);
                #region store Total Sub Duty Payable
                UserTariffExtraTax TotalSubDutyPayble = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Total Duty Payable",
                    TaxValue = TotalSubDutyPayable,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(TotalSubDutyPayble);
               await _context.SaveChangesAsync(cancellationToken);
                #endregion

                var TotalDutyPayable = Math.Round(TotalSubDutyPayable * exchangeRate.Rate, 2).ToString("#,##0.00");
                #region store Total Duty Payable (Local Currency)
                UserTariffExtraTax TotalDutyPaybleInLocalCurrency = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Total Duty Payable (Local Currency)",
                    TaxValue = decimal.Parse(TotalDutyPayable),
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(TotalDutyPaybleInLocalCurrency);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #endregion


                var validate = await _context.UserHSCodePools.Where(x=>x.HsCode==hsCode && x.TransactionId==userhscode.TransactionId).FirstOrDefaultAsync(cancellationToken);
               // var getTariff = await _context.UserTariffExtraTaxes.Where(x => x.TransactionId == userhscode.TransactionId).ToListAsync(cancellationToken); //_context.UserTariffs.Include(x => x.HSCodeTariffTax).Where(x => x.HSCodePool.Country.CountryName == "GH" && x.HSCodePool.HSCode == hsCode && x.HSCodeTariffTax.IsActive == true).ProjectTo<UserTariffDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                return validate;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

        }

        public async Task<UserHSCodePool> GeneralGoodsCalculationNigeria(int Id, string hsCode, decimal Fob, decimal freight, decimal insurance, int currencyId, int countryId, string StandardUnitOfQuantity, int exportingCountryId, string keyword, string containerSize, CancellationToken cancellationToken)
        {
            try
            {
                var exchangeRate = await _context.ExchangeRates.Where(x => x.CurrencyId == currencyId && x.CountryId==countryId).OrderByDescending(x => x.Week).FirstOrDefaultAsync();

                decimal ProductValue = Fob;
                decimal CIF = ProductValue + freight + insurance;

                #region store user hs code pool               
                UserHSCodePool userhscode = new UserHSCodePool
                {
                    HsCode = hsCode,
                    FOB = Fob,
                    Freight = freight,
                    Insurance = insurance,
                    CurrencyId = currencyId,
                    CountryId = countryId,
                    UserId = _currentUserService.GetUserId(),
                    TransactionDate = DateTime.Now,
                    TransactionId = Guid.NewGuid(),
                    StandardUnitOfQuantity = StandardUnitOfQuantity,
                    ExportingCountryId = exportingCountryId,
                    Keyword = keyword,
                    ContainerSize = containerSize

                };
                _context.UserHSCodePools.Add(userhscode);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region Taxes are here
                var getImportDuty = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 1 && x.HsCodePoolId == Id && x.HSCodePool.CountryId==countryId);
                var getImportVat = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 2 && x.HsCodePoolId == Id && x.HSCodePool.CountryId == countryId);
                var getImportLevy = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 9 && x.HsCodePoolId == Id && x.HSCodePool.CountryId == countryId);
                #endregion


                #region old calculation

                // var TotalCIF =(CIF * exchangeRate.Rate).ToString("#,##0.00");


                // var importduty = getImportDuty.TariffValue / 100;

                // var TotalImportDuty = (decimal.Parse(TotalCIF, System.Globalization.NumberStyles.Currency) * importduty).ToString("#,##0.00");

                ///// var Surcharge = new decimal(7, 0, 0, false, 2);
                // decimal Surcharge = 0.07m;
                // decimal TotalSurcharge = Surcharge  * Math.Floor(decimal.Parse(TotalImportDuty));

                // var CISS = new decimal(1, 0, 0, false, 2);
                // decimal TotalCISS = Math.Floor((CISS  * ProductValue + 500 * exchangeRate.Rate));

                // //var ETLS = new decimal(5, 0, 0, false, 2);
                // decimal ETLS = 0.005m;
                // var TotalETLS = Math.Floor(ETLS * decimal.Parse(TotalCIF, System.Globalization.NumberStyles.Currency));

                // var vat1 = getImportVat.TariffValue / 100; 

                // decimal totalcharges = Math.Floor(decimal.Parse(TotalCIF) + decimal.Parse(TotalImportDuty) + decimal.Parse(TotalSurcharge.ToString()) + TotalCISS + TotalETLS);
                // var totalvat = vat1 * totalcharges;
                #endregion


                #region store import duty
                UserTariffExtraTax importduty = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Import Duty",
                    TaxValue = getImportDuty.TariffValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getImportDuty.IsRate
                };
                _context.UserTariffExtraTaxes.Add(importduty);
                await _context.SaveChangesAsync(cancellationToken);

                #endregion

                #region store import vat
                UserTariffExtraTax importvat = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Import Vat",
                    TaxValue = getImportVat.TariffValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getImportVat.IsRate,
                };
                _context.UserTariffExtraTaxes.Add(importvat);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region store import levy
                UserTariffExtraTax importnhil = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Import Levy",
                    TaxValue = getImportLevy.TariffValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getImportLevy.IsRate,
                };
                _context.UserTariffExtraTaxes.Add(importnhil);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion



                decimal vatValue = getImportVat.TariffValue / 100;
                decimal DutyValue = getImportDuty.TariffValue / 100;
                decimal levyValue = getImportLevy.TariffValue / 100;

                decimal NewSurcharge = 0.7m;
                decimal NewETLS = 0.5m;
                decimal NewCISS = 0.1m;

                decimal NewCost = ProductValue + freight;
                decimal TotalCost = NewCost;
                decimal TotalNewCIF = TotalCost;

                decimal DutyPayable = (TotalCost * getImportDuty.TariffValue) / 100;


                #region store fob
                UserTariffExtraTax fob = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Product Value",
                    TaxValue = ProductValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(fob);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region store CIF
                UserTariffExtraTax cif = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "CIF",
                    TaxValue = NewCost,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(cif);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region store rate
                UserTariffExtraTax rate = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Exchange Rate",
                    TaxValue = exchangeRate.Rate,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(rate);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion


                decimal TotalSurcharge =  (DutyPayable * NewSurcharge);
                #region store Surcharge
                UserTariffExtraTax Surcharge = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Surcharge",
                    TaxValue = TotalSurcharge,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(Surcharge);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion


                decimal TotalETLS =  (TotalNewCIF * NewETLS);
                #region store ETLS 
                UserTariffExtraTax ETLS= new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "ETLS",
                    TaxValue = TotalETLS,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(ETLS);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                decimal TotalCISS = (ProductValue  * NewCISS);
                #region store CISS 
                UserTariffExtraTax CISS = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "CISS",
                    TaxValue = TotalCISS,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(CISS);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion
                decimal TotalLevy = (levyValue * TotalNewCIF) / 100;

                #region store Levy 
                UserTariffExtraTax levy = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Import Levy Payale",
                    TaxValue = TotalLevy,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(levy);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region vat calculation

                decimal subtotal = Math.Round(DutyPayable + TotalSurcharge + TotalETLS + TotalCISS + TotalLevy);

                decimal TotalVat = Math.Round(vatValue * subtotal);

                decimal DutyPable = Math.Round(TotalVat * exchangeRate.Rate, 2);

               var DutytoPable = Math.Round(DutyPable + insurance).ToString("#,##0.00");
                #endregion

                #region store dutypayable 
                UserTariffExtraTax payable = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Total Payable to Nigeria Customs",
                    TaxValue = decimal.Parse(DutytoPable),
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(payable);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion


                var validate = await _context.UserHSCodePools.Where(x => x.HsCode == hsCode && x.TransactionId == userhscode.TransactionId).FirstOrDefaultAsync(cancellationToken);
              
                return validate;


            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<UserHSCodePool> GeneralGoodsTrialGhana(string GuestCookie, int Id, string hsCode, decimal Fob, decimal freight, decimal insurance, int currencyId, int countryId, string StandardUnitOfQuantity, int exportingCountryId, string keyword, string containerSize, CancellationToken cancellationToken)

        {
            try
            {
                var exchangeRate = await _context.ExchangeRates.Where(x => x.CurrencyId == currencyId && x.CountryId == countryId).OrderByDescending(x => x.Week).FirstOrDefaultAsync();

                decimal ProductValue = Fob;

                decimal TotalCIF = (ProductValue + freight) + insurance;

                #region store user hs code pool               
                UserHSCodePool userhscode = new UserHSCodePool
                {
                    HsCode = hsCode,
                    FOB = Fob,
                    Freight = freight,
                    Insurance = insurance,
                    CurrencyId = currencyId,
                    CountryId = countryId,
                    UserId = GuestCookie, 
                    TransactionDate = DateTime.Now,
                    TransactionId = Guid.NewGuid(),
                    StandardUnitOfQuantity = StandardUnitOfQuantity,
                    ExportingCountryId = exportingCountryId,
                    Keyword = keyword,
                    ContainerSize = containerSize

                };
                _context.UserHSCodePools.Add(userhscode);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region Taxes are here
                var getImportDuty = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 1 && x.HsCodePoolId == Id);
                var getImportVat = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 2 && x.HsCodePoolId == Id);
                var getImportNHIL = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 3 && x.HsCodePoolId == Id);
                var getImportExcise = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 4 && x.HsCodePoolId == Id);
                var getAfricanUnionImportlevy = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 5 && x.HsCodePoolId == Id);
                var getCasseteLevy = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 6 && x.HsCodePoolId == Id);
                var getTotalEnivronmentalExcise = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 7 && x.HsCodePoolId == Id);
                var getProcessfee = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 8 && x.HsCodePoolId == Id);
                var getImportLevy = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 9 && x.HsCodePoolId == Id);
                var getFund = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 10 && x.HsCodePoolId == Id);
                #endregion


                #region store import duty
                UserTariffExtraTax importduty = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Import Duty",
                    TaxValue = getImportDuty.TariffValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getImportDuty.IsRate
                };
                _context.UserTariffExtraTaxes.Add(importduty);
                await _context.SaveChangesAsync(cancellationToken);

                #endregion

                #region store import vat
                UserTariffExtraTax importvat = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Import Vat",
                    TaxValue = getImportVat.TariffValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getImportVat.IsRate,
                };
                _context.UserTariffExtraTaxes.Add(importvat);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region store import nhil
                UserTariffExtraTax importnhil = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Import NHIL",
                    TaxValue = getImportNHIL.TariffValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getImportNHIL.IsRate,
                };
                _context.UserTariffExtraTaxes.Add(importnhil);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region store fob
                UserTariffExtraTax fob = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Item FOB",
                    TaxValue = ProductValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(fob);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region store CIF
                UserTariffExtraTax cif = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "CIF",
                    TaxValue = TotalCIF,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(cif);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region store rate
                UserTariffExtraTax rate = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Exchange Rate",
                    TaxValue = exchangeRate.Rate,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(rate);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion



                #region Calculated Taxes
                //Total Import duty Payble
                decimal DutyPayable = (TotalCIF * getImportDuty.TariffValue) / 100;

                //Total Get Fund
                decimal TotalGetFund = ((TotalCIF + DutyPayable + getImportExcise.TariffValue) * (getFund.TariffValue / 100));
                #region store get fund
                UserTariffExtraTax fund = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Get Fund",
                    TaxValue = TotalGetFund,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(fund);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion



                //Total Processing Fees
                decimal TotalProcessingFee = (getProcessfee.TariffValue / 100) * TotalGetFund;
                #region //Insert Processing Fees
                //UserTariff userTariffProcessing = new UserTariff
                //{
                //    HsCodePoolId = Id,
                //    HSCodeTariffTaxId = getProcessfee.Id,
                //    TariffValue = getProcessfee.TariffValue,
                //    IsRate = getProcessfee.IsRate,
                //    UserId = _currentUserService.GetUserId(),
                //    TransactionId = userhscode.TransactionId
                //};
                //_context.UserTariffs.Add(userTariffProcessing);
                //await _context.SaveChangesAsync(cancellationToken);
                #endregion



                //Total Ecowas Leve 
                decimal TotalEcowasLevy = new decimal(5, 0, 0, false, 3) * TotalCIF;
                #region store Ecowas Levy
                UserTariffExtraTax EcowasLevy = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Ecowas Levy",
                    TaxValue = TotalEcowasLevy,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(EcowasLevy);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total casseteLevy
                decimal TotalCasseteLevy = (getCasseteLevy.TariffValue / 100) * TotalCIF;
                #region store Cassete Levy
                UserTariffExtraTax CasseteLevy = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Cassete Levy",//getCasseteLevy.HSCodeTariffTax.TaxName,
                    TaxValue = TotalCasseteLevy,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getCasseteLevy.IsRate
                };
                _context.UserTariffExtraTaxes.Add(CasseteLevy);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total Customs Inspection 
                decimal TotalCustomsInspection = new decimal(1, 0, 0, false, 2) * TotalCIF;
                #region store Customs Inspection
                UserTariffExtraTax Inspection = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Customs Inspection Fee",
                    TaxValue = TotalCustomsInspection,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(Inspection);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total IRSTaxDeposit
                decimal TotalIRSTaxDeposit = new decimal(1, 0, 0, false, 2) * TotalCIF;
                #region store IRSTaxDeposit
                UserTariffExtraTax IRSTaxDeposit = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "IRS Tax Deposit",
                    TaxValue = TotalIRSTaxDeposit,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(IRSTaxDeposit);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total ImportLevey
                decimal TotalImportLevey = (getImportLevy.TariffValue / 100) * TotalCIF;
                #region store Import Levy
                UserTariffExtraTax ImportLevy = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Import Levy",//getImportLevy.HSCodeTariffTax.TaxName,
                    TaxValue = TotalImportLevey,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(ImportLevy);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion



                //Total EnivronmentalExcise
                decimal TotalEnivronmentalExcise = (getTotalEnivronmentalExcise.TariffValue / 100) * TotalCIF;
                #region store Enivronmental Excise
                UserTariffExtraTax Excise = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Enivronmental Excise", //getTotalEnivronmentalExcise.HSCodeTariffTax.TaxName,
                    TaxValue = TotalEnivronmentalExcise,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getTotalEnivronmentalExcise.IsRate
                };
                _context.UserTariffExtraTaxes.Add(Excise);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total SIL 
                decimal TotalSIL = new decimal(2, 0, 0, false, 2) * TotalCIF;
                #region store Speacial Import Levy
                UserTariffExtraTax Speacial = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Special Import Levy",
                    TaxValue = TotalSIL,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(Speacial);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion


                //Total EXIM              
                decimal TotalEXIM = new decimal(75, 0, 0, false, 4) * TotalCIF;
                #region store EXIM
                UserTariffExtraTax EXIM = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "EXIM",
                    TaxValue = TotalEXIM,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(EXIM);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total africanUnionImportlevy
                decimal totalafricanUnionImportlevy = (getAfricanUnionImportlevy.TariffValue / 100);
                #region store african union
                UserTariffExtraTax africanUnionImportlevy = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "African Union Import Levy",//getAfricanUnionImportlevy.HSCodeTariffTax.TaxName,
                    TaxValue = totalafricanUnionImportlevy,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getAfricanUnionImportlevy.IsRate
                };
                _context.UserTariffExtraTaxes.Add(africanUnionImportlevy);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total Duty Payable (Import Duty)                   
                decimal TotalImporttExcise = (getImportExcise.TariffValue * exchangeRate.Rate);


                //Total african union
                decimal TotalAfricanUnion = TotalImporttExcise;

                #region store Total Duty Payble
                UserTariffExtraTax TotalDutyPayble = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Duty Payable (Import Duty)",
                    TaxValue = DutyPayable,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(TotalDutyPayble);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total NHILPayble
                decimal TotalNHILPayble = ((TotalCIF + DutyPayable) + getImportExcise.TariffValue) * (getImportNHIL.TariffValue / 100);
                #region store NHIL Payble
                UserTariffExtraTax NHILPayble = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "NHIL Payable",
                    TaxValue = TotalNHILPayble,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false,
                };
                _context.UserTariffExtraTaxes.Add(NHILPayble);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion



                //Total VatPayable
                decimal TotalVatpayable = Math.Round(TotalCIF + DutyPayable + getImportExcise.TariffValue + TotalGetFund + TotalNHILPayble + TotalAfricanUnion + TotalEXIM + TotalSIL + TotalEnivronmentalExcise + TotalImportLevey + TotalIRSTaxDeposit + TotalCustomsInspection + TotalCasseteLevy + TotalEcowasLevy + TotalProcessingFee * (getImportVat.TariffValue / 100), 2);
                #region store VAT Payble
                UserTariffExtraTax VatPayble = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "VAT Payable",
                    TaxValue = TotalVatpayable,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(VatPayble);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                //Total Sub Duty Payable & Total Duty Payable
                decimal TotalSubDutyPayable = Math.Round((DutyPayable + TotalVatpayable) + TotalNHILPayble, 2);
                #region store Total Sub Duty Payable
                UserTariffExtraTax TotalSubDutyPayble = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Total Duty Payable",
                    TaxValue = TotalSubDutyPayable,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(TotalSubDutyPayble);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                var TotalDutyPayable = Math.Round(TotalSubDutyPayable * exchangeRate.Rate, 2).ToString("#,##0.00");
                #region store Total Duty Payable (Local Currency)
                UserTariffExtraTax TotalDutyPaybleInLocalCurrency = new UserTariffExtraTax
                {
                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Total Duty Payable (Local Currency)",
                    TaxValue = decimal.Parse(TotalDutyPayable),
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(TotalDutyPaybleInLocalCurrency);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #endregion

                var GetOldUse = _context.GuestUsers.Where(x => x.Ip == GuestCookie).FirstOrDefault();
                int OneUse = 1;
                int UseRemain = GetOldUse.NoOfUse - OneUse;
                int totalUse = UseRemain;
                GetOldUse.NoOfUse = totalUse;
                await _context.SaveChangesAsync(cancellationToken);               

                var validate = await _context.UserHSCodePools.Where(x => x.HsCode == hsCode && x.TransactionId == userhscode.TransactionId).FirstOrDefaultAsync(cancellationToken);                
                return validate;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

        }

        public async Task<UserHSCodePool> GeneralGoodsTrialNigeria(string GuestCookie,int Id, string hsCode, decimal Fob, decimal freight, decimal insurance, int currencyId, int countryId, string StandardUnitOfQuantity, int exportingCountryId, string keyword, string containerSize, CancellationToken cancellationToken)
        {
            try
            {
                var exchangeRate = await _context.ExchangeRates.Where(x => x.CurrencyId == currencyId && x.CountryId == countryId).OrderByDescending(x => x.Week).FirstOrDefaultAsync();

                decimal ProductValue = Fob;
                decimal CIF = ProductValue + freight + insurance;

                #region store user hs code pool               
                UserHSCodePool userhscode = new UserHSCodePool
                {
                    HsCode = hsCode,
                    FOB = Fob,
                    Freight = freight,
                    Insurance = insurance,
                    CurrencyId = currencyId,
                    CountryId = countryId,
                    UserId = GuestCookie,
                    TransactionDate = DateTime.Now,
                    TransactionId = Guid.NewGuid(),
                    StandardUnitOfQuantity = StandardUnitOfQuantity,
                    ExportingCountryId = exportingCountryId,
                    Keyword = keyword,
                    ContainerSize = containerSize

                };
                _context.UserHSCodePools.Add(userhscode);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region Taxes are here
                var getImportDuty = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 1 && x.HsCodePoolId == Id && x.HSCodePool.CountryId == countryId);
                var getImportVat = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 2 && x.HsCodePoolId == Id && x.HSCodePool.CountryId == countryId);
                var getImportLevy = _context.tariffs.FirstOrDefault(x => x.HSCodeTariffTaxId == 9 && x.HsCodePoolId == Id && x.HSCodePool.CountryId == countryId);
                #endregion


                #region old calculation

                // var TotalCIF =(CIF * exchangeRate.Rate).ToString("#,##0.00");


                // var importduty = getImportDuty.TariffValue / 100;

                // var TotalImportDuty = (decimal.Parse(TotalCIF, System.Globalization.NumberStyles.Currency) * importduty).ToString("#,##0.00");

                ///// var Surcharge = new decimal(7, 0, 0, false, 2);
                // decimal Surcharge = 0.07m;
                // decimal TotalSurcharge = Surcharge  * Math.Floor(decimal.Parse(TotalImportDuty));

                // var CISS = new decimal(1, 0, 0, false, 2);
                // decimal TotalCISS = Math.Floor((CISS  * ProductValue + 500 * exchangeRate.Rate));

                // //var ETLS = new decimal(5, 0, 0, false, 2);
                // decimal ETLS = 0.005m;
                // var TotalETLS = Math.Floor(ETLS * decimal.Parse(TotalCIF, System.Globalization.NumberStyles.Currency));

                // var vat1 = getImportVat.TariffValue / 100; 

                // decimal totalcharges = Math.Floor(decimal.Parse(TotalCIF) + decimal.Parse(TotalImportDuty) + decimal.Parse(TotalSurcharge.ToString()) + TotalCISS + TotalETLS);
                // var totalvat = vat1 * totalcharges;
                #endregion


                #region store import duty
                UserTariffExtraTax importduty = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Import Duty",
                    TaxValue = getImportDuty.TariffValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getImportDuty.IsRate
                };
                _context.UserTariffExtraTaxes.Add(importduty);
                await _context.SaveChangesAsync(cancellationToken);

                #endregion

                #region store import vat
                UserTariffExtraTax importvat = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Import Vat",
                    TaxValue = getImportVat.TariffValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getImportVat.IsRate,
                };
                _context.UserTariffExtraTaxes.Add(importvat);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region store import levy
                UserTariffExtraTax importnhil = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Import Levy",
                    TaxValue = getImportLevy.TariffValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = getImportLevy.IsRate,
                };
                _context.UserTariffExtraTaxes.Add(importnhil);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion



                decimal vatValue = getImportVat.TariffValue / 100;
                decimal DutyValue = getImportDuty.TariffValue / 100;
                decimal levyValue = getImportLevy.TariffValue / 100;

                decimal NewSurcharge = 0.7m;
                decimal NewETLS = 0.5m;
                decimal NewCISS = 0.1m;

                decimal NewCost = ProductValue + freight;
                decimal TotalCost = NewCost;
                decimal TotalNewCIF = TotalCost;

                decimal DutyPayable = (TotalCost * getImportDuty.TariffValue) / 100;


                #region store fob
                UserTariffExtraTax fob = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Product Value",
                    TaxValue = ProductValue,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(fob);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region store CIF
                UserTariffExtraTax cif = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "CIF",
                    TaxValue = NewCost,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(cif);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region store rate
                UserTariffExtraTax rate = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Exchange Rate",
                    TaxValue = exchangeRate.Rate,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(rate);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion


                decimal TotalSurcharge = (DutyPayable * NewSurcharge);
                #region store Surcharge
                UserTariffExtraTax Surcharge = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Surcharge",
                    TaxValue = TotalSurcharge,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(Surcharge);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion


                decimal TotalETLS = (TotalNewCIF * NewETLS);
                #region store ETLS 
                UserTariffExtraTax ETLS = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "ETLS",
                    TaxValue = TotalETLS,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(ETLS);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                decimal TotalCISS = (ProductValue * NewCISS);
                #region store CISS 
                UserTariffExtraTax CISS = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "CISS",
                    TaxValue = TotalCISS,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(CISS);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion
                decimal TotalLevy = (levyValue * TotalNewCIF) / 100;

                #region store Levy 
                UserTariffExtraTax levy = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Import Levy Payale",
                    TaxValue = TotalLevy,
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(levy);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region vat calculation

                decimal subtotal = Math.Round(DutyPayable + TotalSurcharge + TotalETLS + TotalCISS + TotalLevy);

                decimal TotalVat = Math.Round(vatValue * subtotal);

                decimal DutyPable = Math.Round(TotalVat * exchangeRate.Rate, 2);

                var DutytoPable = Math.Round(DutyPable + insurance).ToString("#,##0.00");
                #endregion

                #region store dutypayable 
                UserTariffExtraTax payable = new UserTariffExtraTax
                {

                    UserHSCodePoolId = userhscode.Id,
                    TaxName = "Total Payable to Nigeria Customs",
                    TaxValue = decimal.Parse(DutytoPable),
                    TransactionId = userhscode.TransactionId,
                    IsRate = false
                };
                _context.UserTariffExtraTaxes.Add(payable);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion


                var GetOldUse = _context.GuestUsers.Where(x => x.Ip == GuestCookie).FirstOrDefault();
                int OneUse = 1;
                int UseRemain = GetOldUse.NoOfUse - OneUse;
                int totalUse = UseRemain;
                GetOldUse.NoOfUse = totalUse;
                await _context.SaveChangesAsync(cancellationToken);

                var validate = await _context.UserHSCodePools.Where(x => x.HsCode == hsCode && x.TransactionId == userhscode.TransactionId).FirstOrDefaultAsync(cancellationToken);

                return validate;


            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        public  List<string> GetHsCodeList(string hsCode)
        {
            var code =  _context.HSCodePools.Where(p => p.HSCode.StartsWith(hsCode)).Select(x=>x.HSCode).ToList();
           return code;
        }


        public IList<TariffBenchmark> GetTariffBenchmark(string heading)
        {
            var fvar = heading.Substring(0, 4);
            var Benchmark = _context.TariffBenchmarks.Where(x => x.HSCode == fvar).ToList();
            return Benchmark;
        }

        public IList<Agency> GetAgency(string hscode, int countryId)
        {
            var gethscode = (from a in _context.Agencies
                             join h in _context.AgencyHsCodes on a.Id equals h.AgencyId
                             join c in _context.HSCodePools on h.HsCodePoolId equals c.Id
                             where c.HSCode == hscode && c.CountryId==countryId
                             select a).ToList();
            return gethscode;
        }

        public IList<DocumentType> GetDocumentTypes(int AgencyId, string hscode, int countryId)
        {
           var gethscode = _context.HSCodePools.Where(x => x.HSCode == hscode && x.CountryId==countryId).FirstOrDefault();
            var getdocument = (from a in _context.Agencies                               
                               join ad in _context.AgencyHsCodes on a.Id equals ad.AgencyId
                               join d in _context.DocumentTypes on ad.DocumentTypeId equals d.Id
                               where a.Id==AgencyId && ad.HsCodePoolId== gethscode.Id
                               select d).ToList();
            return getdocument;
        }
        public IList<ExtraDocumentValue> GetExtraDocumentValues(int agencyHsCodeId)
        {
            var getagency = _context.AgencyHsCodes.Where(x => x.Id == agencyHsCodeId).Select(x=>x.AgencyId).ToList();
            var getextraDoc = _context.ExtraDocumentValues.Where(x => getagency.Contains(x.AgencyHsCodeId)).Distinct().ToList();
            return getextraDoc;

        }

        public IList<string> GetDocumentCategories(string hscode, int countryId)
        {
            var gethscode = _context.HSCodePools.Where(x => x.HSCode == hscode && x.CountryId == countryId).FirstOrDefault();
            var docmentCategory = (from hd in _context.HSCodeRecords
                                   join h in _context.HSCodePools on hd.HsCodePoolId equals h.Id                                 
                                   join dc in _context.DocumentCategories on hd.DocumentCategoryId equals dc.Id
                                   join ah in _context.AgencyHsCodes on hd.HsCodePoolId equals ah.HsCodePoolId
                                   where hd.HsCodePoolId == gethscode.Id && h.CountryId==countryId 
                                   select dc.CategoryName
                                   ).Distinct().ToList();
            return docmentCategory;
        }

        public List<string> GetDocument(string hscode, string category, int countryId)
        {
            var gethscode = _context.HSCodePools.Where(x => x.HSCode == hscode && x.CountryId == countryId).FirstOrDefault();
            var getcat = _context.DocumentCategories.Where(x => x.CategoryName == category).FirstOrDefault();
            var getdocuments = (from hd in _context.HSCodeRecords
                                join pool in _context.HSCodePools on hd.HsCodePoolId equals pool.Id                             
                                join dc in _context.DocumentCategories on hd.DocumentCategoryId equals dc.Id
                                where hd.HsCodePoolId == gethscode.Id && hd.DocumentCategory.CategoryName == category
                                select hd.Docs).Distinct().ToList();
            
            return getdocuments;
        }
        public Sector GetSector(string hscode)
        {
            var fvar = hscode.Substring(0, 2);
            var GetSegment = (from s in _context.Segments
                              join c in _context.Sectors on s.SectorId equals c.Id 
                              where s.Code == fvar 
                              select c).FirstOrDefault();
            return GetSegment;
        }

        public Segment GetSegment(string hscode)
        {
            var fvar = hscode.Substring(0, 2);
            var GetSeg = (from s in _context.Segments                             
                              where s.Code == fvar
                              select s).FirstOrDefault();
            return GetSeg;
        }

        public AgencyHsCode GetAgencyHsCode(string hscode, int countryId)
        {
            var gethscode = _context.HSCodePools.Where(x => x.HSCode == hscode && x.CountryId == countryId).FirstOrDefault();
            var getAgencuhscode = _context.AgencyHsCodes.Where(x => x.HsCodePoolId == gethscode.Id).FirstOrDefault();
            return getAgencuhscode;
        }
        public List<AgencyHsCode> GetAgencyDocuments(int HscodeId)
        {
             var agencies = _context.AgencyHsCodes.Where(x => x.HsCodePoolId == HscodeId).Distinct().ToList();
            // var getdoc = (from d in _context.DocumentTypes where d.Id) //_context.DocumentTypes.Where(x => x.Id).ToList();
            //var getAgecyDoc = (from a in _context.AgencyHsCodes where a.HsCodePoolId == HscodeId select a.DocumentTypeId).ToList();
            //List<string> lists = new List<string>();
            //foreach (var acc in getAgecyDoc)
            //{
            //    var getDoc = (from a in _context.DocumentTypes where a.Id == acc select a).ToList();
            //    lists.Add(acc.ToString());
            //}
            return agencies;
        }

        public List<DocumentType> GetDocumentType()
        {
            var getdocumentType = (from d in _context.DocumentTypes where d.IsActive == true select d).ToList();
            return getdocumentType;
        }

        public List<AgencyHsCode> AgencyHsCodes(string hscode, int countryId)
        {
            var GetAgencies = (from h in _context.HSCodePools
                             join a in _context.AgencyHsCodes on h.Id equals a.HsCodePoolId
                             where h.HSCode == hscode && h.CountryId == countryId
                             select a).ToList();
            return GetAgencies;
        }




    }
}
