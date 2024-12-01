using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Features.Restaurants.Commands.RestaurantCreate;
using Restaurant.Application.Features.Restaurants.Commands.RestaurantDelete;
using Restaurant.Application.Features.Restaurants.Queries.GetAllRestaurant;

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator mediator;
        public RestaurantController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(RestaurantCreateCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await mediator.Send(new RestaurantDeleteCommandRequest());
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page,int size)
        {
            var response = await mediator.Send(new GetAllRestaurantQueryRequest() { Page = page, PageSize = size });
            return Ok(response);
        }
    }
}
