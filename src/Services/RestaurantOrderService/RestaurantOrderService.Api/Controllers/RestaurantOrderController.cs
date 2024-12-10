using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderService.Application.Features.OrderItems.Commands.ChangeOrderStatusToAccepted;
using RestaurantOrderService.Application.Features.OrderItems.Commands.ChangeOrderStatusToCompleted;
using RestaurantOrderService.Application.Features.OrderItems.Commands.ChangeOrderStatusToRejected;
using RestaurantOrderService.Application.Features.OrderItems.Queries.GetAllAcceptedByBranchId;
using RestaurantOrderService.Application.Features.OrderItems.Queries.GetAllPendingByBranchId;

namespace RestaurantOrderService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RestaurantOrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public RestaurantOrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatusToAccepted(ChangeOrderStatusToAcceptedCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatusToCompleted(ChangeOrderStatusToCompletedCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatusToRejected(ChangeOrderStatusToRejectedCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetPendingOrders([FromQuery] Guid branchId)
        {
            var response = await mediator.Send(new GetAllPendingByBranchIdQueryRequest() { BranchId = branchId });
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAcceptedOrders([FromQuery] Guid branchId)
        {
            var response = await mediator.Send(new GetAllAcceptedByBranchIdQueryRequest() { BranchId = branchId });
            return Ok(response);
        }
    }
}
