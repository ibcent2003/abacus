using System.Collections.Generic;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class WorkFlowCommandModel : IPayLoadObject
    {
        public string CommandName { get; set; }
        public string LocalizedName { get; set; }
        public string Classifier { get; set; }
        public bool IsForSubprocess { get; set; }
        public string ValidForStateName { get; set; }
        public string ValidForActivityName { get; set; }
        public string ProcessId { get; set; }
        public IList<string> Identities { get; set; }
        public IList<WorkFlowCommandParameterModel> Parameters { get; set; }
    }
}
