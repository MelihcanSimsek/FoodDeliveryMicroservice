using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Application.Features.Accounts.Commands.AddBalanceWithMethod;
using PaymentService.Application.Features.Accounts.Commands.AddBalanceWithSavedMethod;
using PaymentService.Application.Features.Accounts.Commands.CheckBalanceForOrder;
using PaymentService.Application.Features.Accounts.Commands.CreateAccount;
using PaymentService.Application.Features.Accounts.Queries.GetUserAccount;
using PaymentService.Application.Features.Payments.Queries.GetAllUserPaymentMethods;

namespace PaymentService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            await mediator.Send(new CreateAccountCommandRequest());
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> CheckBalanceForOrder(CheckBalanceForOrderCommandRequest request)
        {
            await mediator.Send(request);

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> AddBalanceWithSavedMethod(AddBalanceWithSavedMethodCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        public async Task<IActionResult> AddBalanceWithMethod(AddBalanceWithMethodCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new GetUserAccountQueryRequest());
            return Ok(response);
        }
    }
}
