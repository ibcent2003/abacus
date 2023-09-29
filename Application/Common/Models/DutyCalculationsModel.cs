using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Application.Common.Models
{
   public class DutyCalculationsModel
    {
        public string cif { get; set; }
        public string cifafterdedution { get; set; }
        public string depreciation { get; set; }
        public string depreciationafterdedution { get; set; }
        public string ecowas { get; set; }
        public string ecowasafterdedution { get; set; }
        public string edif { get; set; }
        public string edifafterdedution { get; set; }
        public string examfee { get; set; }
        public string examfeeafterdedution { get; set; }
        public decimal FOB { get; set; }
        public decimal FOBafterdedution { get; set; }
        public string freight { get; set; }
        public string freightafterdedution { get; set; }
        public string ghcedis { get; set; }
        public string ghcedisafterdedution { get; set; }
        public string Hscode { get; set; }
        public string Hscodeafterdedution { get; set; }
        public string Importduty { get; set; }
        public string Importdutyafterdedution { get; set; }
        public decimal insurance { get; set; }
        public decimal insuranceafterdedution { get; set; }
        public string interestCharge { get; set; }
        public string interestChargeafterdedution { get; set; }
        public string localCurrency { get; set; }
        public string localCurrencyafterdedution { get; set; }
        public string NetchargeNhil { get; set; }
        public string NetchargeNhilafterdedution { get; set; }
        public string NetchargeVat { get; set; }
        public string NetchargeVatafterdedution { get; set; }
        public string networkCharge { get; set; }
        public string networkChargeafterdedution { get; set; }
        public string nhil { get; set; }
        public string nhilafterdedution { get; set; }
        public string Overage { get; set; }
        public string Overageafterdedution { get; set; }
        public string ProcessingFee { get; set; }
        public string ProcessingFeeafterdedution { get; set; }
        public string rate { get; set; }
        public string rateafterdedution { get; set; }
        public string shppers { get; set; }
        public string shppersafterdedution { get; set; }
        public string specialLevy { get; set; }
        public string specialLevyafterdedutiony { get; set; }
        public string vat { get; set; }
        public string vatafterdedution { get; set; }
    }
}
