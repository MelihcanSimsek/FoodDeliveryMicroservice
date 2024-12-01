using MediatR;
using Menu.Application.Features.Meals.Commands.CreateMeal;
using Menu.Application.Features.Meals.Commands.DeleteMeal;
using Menu.Application.Features.Meals.Commands.UpdateMeal;
using Menu.Application.Features.Meals.Queries.GetAllMeal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Menu.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMediator mediator;

        public MealController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateMealCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteMealCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMealCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]int size,[FromQuery] int page,[FromQuery] Guid restaurantId)
        {
            var response = await mediator.Send(new GetAllMealQueryRequest() { RestaurantId = restaurantId, Page = page, Size = size });
            return Ok(response);
        }
    }
}
