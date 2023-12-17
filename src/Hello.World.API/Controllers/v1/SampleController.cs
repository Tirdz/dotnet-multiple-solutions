using Hello.World.Business.Features.Commands.Create;
using Hello.World.Business.Features.Commands.Update;
using Hello.World.Business.Features.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace Hello.World.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SampleController : ApiControllerBase
    {
        [MapToApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllSampleQuery()));
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Add(CreateSampleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [MapToApiVersion("1.0")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(int id, UpdateSampleCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }
    }
}
