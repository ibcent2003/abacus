using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Attributes;

namespace Application.Common.Enums
{
   public enum DocumentTags
    {
        [StringValue("Export")]
        Export,
        [StringValue("Import")]
        Import,
        [StringValue("Both")]
        Both,
    }
}
