using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Application.Features.Payments.Commands.AddPaymentMethod;
using PaymentService.Application.Features.Payments.Commands.DeletePaymentMethod;
using PaymentService.Application.Features.Payments.Queries.GetAllUserPaymentMethods;

namespace PaymentService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator mediator;
        public PaymentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPaymentMethodCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeletePaymentMethodCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediator.Send(new GetAllUserPaymentMethodsQueryRequest());
            return Ok(response);
        }

    }
}
