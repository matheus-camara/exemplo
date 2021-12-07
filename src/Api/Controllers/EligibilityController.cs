using Domain.Commands.CalculateEligibility;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EligibilityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EligibilityController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CalculateEligiblityForPro([FromBody] CalculateEligibilityForProCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
