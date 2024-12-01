using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Features.Branches.Commands.BranchCreate;
using Restaurant.Application.Features.Branches.Commands.BranchDelete;
using Restaurant.Application.Features.Branches.Queries.GetAllBranch;

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IMediator mediator;
        public BranchController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(BranchCreateCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(BranchDeleteCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page,[FromQuery] int size,[FromQuery] Guid restaurantId)
        {
            var response = await mediator.Send(new GetAllBranchQueryRequest() { RestaurantId = restaurantId, Page = page, Size = size });
            return Ok(response);
        }
    }
}
