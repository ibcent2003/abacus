using System.Collections.Generic;
using System.Globalization;

namespace Wbc.WebUI.Models
{
    public class CultureHandlerModel
    {
        public CultureInfo CurrentUiCulture { get; set; }
        public List<CultureInfo> SupportedCultures { get; set; }
    }
}
