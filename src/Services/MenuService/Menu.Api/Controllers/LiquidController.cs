using MediatR;
using Menu.Application.Features.Liquids.Commands.CreateLiquid;
using Menu.Application.Features.Liquids.Commands.DeleteLiquid;
using Menu.Application.Features.Liquids.Commands.UpdateLiquid;
using Menu.Application.Features.Liquids.Queries.GetAllLiquid;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Menu.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LiquidController : ControllerBase
    {
        private readonly IMediator mediator;

        public LiquidController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateLiquidCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateLiquidCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteLiquidCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page,[FromQuery] int size,[FromQuery] Guid restaurantId)
        {
            var response = await mediator.Send(new GetAllLiquidQueryRequest() { Page = page, Size = size, RestaurantId = restaurantId });
            return Ok(response);
        }
    }
}
