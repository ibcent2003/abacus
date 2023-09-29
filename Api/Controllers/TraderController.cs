using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.APIs.Query.GetTraderApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wbc.Api.Controllers
{
    public class TraderController : ApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<TraderDto>> Get(int id)
        {
            var trader = Mediator.Send(new GetTraderApiQuery { Id = id });

            return await Task.FromResult(Ok(trader));
        }
    }
}
