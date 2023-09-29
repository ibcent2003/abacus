using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Application.Common.Models
{
    public class DocumentCommandModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public OptimaJet.Workflow.Core.Model.TransitionClassifier Classifier { get; set; }
    }
}
