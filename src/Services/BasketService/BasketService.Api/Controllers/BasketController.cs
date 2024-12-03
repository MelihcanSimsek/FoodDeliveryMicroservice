using BasketService.Application.Features.CustomerBaskets.Commands.DeletAllBasket;
using BasketService.Application.Features.CustomerBaskets.Commands.DeleteBasket;
using BasketService.Application.Features.CustomerBaskets.Commands.UpdateBasket;
using BasketService.Application.Features.CustomerBaskets.Queries.GetAllUserBasket;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator mediator;

        public BasketController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBasketCommandRequest request)
        {
            await mediator.Send(request);

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await mediator.Send(new DeleteBasketCommandRequest());

            return StatusCode(StatusCodes.Status200OK);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAll(DeleteAllBasketCommandRequest request)
        {
            await mediator.Send(request);

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var response = await mediator.Send(new GetAllUserBasketQueryRequest());
            return Ok(response);
        }
    }
}
