using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wbc.Application.Subscription.Command.AddSubscriber;
using Wbc.Application.Subscription.Query.GetSubscriber;

namespace Wbc.Api.Controllers
{

    public class SubscriptionController : ApiController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostSubscription([FromBody] AddSubscriberCommand command)
        {

            var result = await Mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { result }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionDto>> Get(int id)
        {

            return await Task.FromResult(Ok(new SubscriptionDto()));
        }
              
    }
}
