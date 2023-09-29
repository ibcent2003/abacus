using Microsoft.AspNetCore.Mvc;
using Wbc.Application.Common.Enums;

namespace Wbc.WebUI.Filter
{
    public class AuthorizePolicyAttribute : TypeFilterAttribute
    {
        public AuthorizePolicyAttribute(Policies policy) : base(typeof(AuthorizePolicyFilter))
        {

            Arguments = new object[] { policy };
        }
    }
}
