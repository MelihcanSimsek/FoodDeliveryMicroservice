using CourierService.Application.Features.Couriers.Commands.ChangeStatusToAvailable;
using CourierService.Application.Features.Couriers.Commands.ChangeStatusToOffline;
using CourierService.Application.Features.Couriers.Commands.ChangeStatusToOnDelivery;
using CourierService.Application.Features.Couriers.Commands.CreateCourier;
using CourierService.Application.Features.Couriers.Commands.DeleteCourier;
using CourierService.Application.Features.Couriers.Queries.GetAllCourier;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourierController : ControllerBase
    {
        private readonly IMediator medaitor;

        public CourierController(IMediator medaitor)
        {
            this.medaitor = medaitor;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCourierCommandRequest request)
        {
            await medaitor.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            await medaitor.Send(new DeleteCourierCommandRequest());

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatusToOffline()
        {
            await medaitor.Send(new ChangeStatusToOfflineCommandRequest());
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatusToAvailable()
        {
            await medaitor.Send(new ChangeStatusToAvailableCommandRequest());
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatusToOnDelivery()
        {
            await medaitor.Send(new ChangeStatusToOnDeliveryCommandRequest());
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActiveCourier()
        {
            var response = await medaitor.Send(new GetAllCourierQueryRequest());
            return Ok(response);
        }
    }
}
