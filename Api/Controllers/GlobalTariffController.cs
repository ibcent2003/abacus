using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wbc.Application.TariffManager.Query.GetGlobalTariff;

namespace Wbc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalTariffController : ApiController
    {
         
 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TarrifVm>> Get(string countryName, string hscode)
        {
            try
            {
                var Countryhscode = await Mediator.Send(new GetTariffHSCodeCountryQuery { CountryName = countryName, hScode = hscode });              
                return new JsonResult(Countryhscode);
            }
            catch(Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
           
        }
       
    }
   
}
