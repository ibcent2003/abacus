using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Wbc.WebUI.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class StatusCodeErrorModel : PageModel
    {
        public string RequestId { get; set; }
        public string ErrorStatusCode { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string OriginalUrl { get; set; }
        public bool ShowOriginalUrl => !string.IsNullOrEmpty(OriginalUrl);

        private readonly ILogger<StatusCodeErrorModel> _logger;

        public StatusCodeErrorModel(ILogger<StatusCodeErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string code)
        {
            ErrorStatusCode = code;
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            var statusCodeReExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            if (statusCodeReExecuteFeature != null)
            {
                OriginalUrl =
                    statusCodeReExecuteFeature.OriginalPathBase
                    + statusCodeReExecuteFeature.OriginalPath
                    + statusCodeReExecuteFeature.OriginalQueryString;
            }
        }
    }
}
