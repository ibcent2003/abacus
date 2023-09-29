using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class WorkFlowCommandParameterModel : IPayLoadObject
    {
        public string ParameterName { get; set; }
        public string LocalizedName { get; set; }
        public string TypeName { get; set; }
        public bool IsRequired { get; set; }
        public string DefaultValue { get; set; }
    }
}
