using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.GeneralGoods.Query;
using Wbc.Domain.Entities;

namespace Wbc.Application.Common.Interfaces
{
    public interface IGeneralGoodsService
    {
        Task<UserHSCodePool> GeneralGoodsCalculationGhana(int Id, string hsCode, decimal Fob, decimal freight, decimal insurance, int currencyId, int countryId, string StandardUnitOfQuantity, int exportingCountryId, string keyword, string containerSize, CancellationToken cancellationToken);
        Task<UserHSCodePool> GeneralGoodsCalculationNigeria(int Id, string hsCode, decimal Fob, decimal freight, decimal insurance, int currencyId, int countryId, string StandardUnitOfQuantity, int exportingCountryId, string keyword, string containerSize, CancellationToken cancellationToken);

        Task<UserHSCodePool> GeneralGoodsTrialGhana(string IP,int Id, string hsCode, decimal Fob, decimal freight, decimal insurance, int currencyId, int countryId, string StandardUnitOfQuantity, int exportingCountryId, string keyword, string containerSize, CancellationToken cancellationToken);
        Task<UserHSCodePool> GeneralGoodsTrialNigeria(string IP,int Id, string hsCode, decimal Fob, decimal freight, decimal insurance, int currencyId, int countryId, string StandardUnitOfQuantity, int exportingCountryId, string keyword, string containerSize, CancellationToken cancellationToken);


        IList<TariffBenchmark> GetTariffBenchmark(string heading);
        List<string> GetHsCodeList(string hsCode);

        IList<Agency> GetAgency(string hscode, int countryId);
        List<AgencyHsCode> AgencyHsCodes(string hscode, int countryId);
        IList<DocumentType> GetDocumentTypes(int AgencyId, string hscode,int countryId);

        IList<ExtraDocumentValue> GetExtraDocumentValues(int agencyHsCodeId);

        IList<string> GetDocumentCategories(string hscode, int countryId);
        List<string> GetDocument(string hscode, string category, int countryId);
        Sector GetSector(string hscode);
        Segment GetSegment(string hscode);
        AgencyHsCode GetAgencyHsCode(string hscode, int countryId);
        List<AgencyHsCode> GetAgencyDocuments(int HscodeId);
        List<DocumentType> GetDocumentType();
        //string GetIP();






    }
}
