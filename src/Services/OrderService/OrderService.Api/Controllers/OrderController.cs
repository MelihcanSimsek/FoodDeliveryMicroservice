using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Features.Orders.Queries.GetAllUserOrders;

namespace OrderService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] int page,[FromQuery] int size)
        {
            var response = await mediator.Send(new GetAllUserOrdersQueryRequest() { Page = page, Size = size });
            return Ok(response);
        }
    }
}
