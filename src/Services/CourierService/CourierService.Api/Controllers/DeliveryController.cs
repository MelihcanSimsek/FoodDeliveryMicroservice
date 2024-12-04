using CourierService.Application.Features.OrderItems.Commands.ChangeStatusToDeliveryFailed;
using CourierService.Application.Features.OrderItems.Commands.ChangeStatusToDeliveryStarted;
using CourierService.Application.Features.OrderItems.Commands.ChangeStatusToOrderCompleted;
using CourierService.Application.Features.OrderItems.Queries.GetAllCourierActiveOrders;
using CourierService.Application.Features.OrderItems.Queries.GetAllPendingOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IMediator mediator;
        public DeliveryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Start(ChangeStatusToDeliveryStartedCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> Fail(ChangeStatusToDeliveryFailedCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> Complete(ChangeStatusToOrderCompletedCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPendingOrder()
        {
            var response = await mediator.Send(new GetAllPendingOrderCommandRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetCourierActiveOrder()
        {
            var response = await mediator.Send(new GetAllCourierActiveOrdersQueryRequest());
            return Ok(response);
        }
    }
}
