using AdminDashboard.API.Reuqests.Client;
using AdminDashboard.API.Reuqests.Payment;
using AdminDashboard.API.Routes;
using AdminDashboard.Entity.Json;
using AdminDashboard.Entity.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.API.Controller
{
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;    
        }

        [HttpPost(ApiRoutes.PaymentRoutes.CreatePayment)]
        public async Task<IActionResult> Create([FromBody] Payment payment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentCreateRequest = new PaymentCreateRequest(payment);
            var clientCommandResult = await _mediator.Send(paymentCreateRequest);

            if (clientCommandResult.IsSuccess)
                return Created();
            else return BadRequest(ModelState);
        }

        [HttpPut(ApiRoutes.PaymentRoutes.UpdatePayment)]
        public async Task<IActionResult> Update([FromBody] Payment payment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentUpdateRequest = new PaymentUpdateRequest(payment);
            var clientCommandResult = await _mediator.Send(paymentUpdateRequest);
            var jsonResult = clientCommandResult.ToJsonContent();

            if (clientCommandResult.IsSuccess)
                return Ok(jsonResult);
            else return BadRequest(ModelState);
        }

        [HttpDelete(ApiRoutes.PaymentRoutes.DeletePayment)]
        public async Task<IActionResult> Delete([FromBody] int paymentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentDeleteRequest = new PaymentDeleteRequest(paymentId);
            var clientCommandResult = await _mediator.Send(paymentDeleteRequest);
            var jsonResult = clientCommandResult.ToJsonContent();

            if (clientCommandResult.IsSuccess)
                return NoContent();
            else return BadRequest(ModelState);
        }

        [HttpGet(ApiRoutes.PaymentRoutes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentGetAllRequest = new PaymentGetAllRequest();
            var clientQueryResult = await _mediator.Send(paymentGetAllRequest);
            var jsonResult = clientQueryResult.ToJsonContent();

            if (clientQueryResult.IsSuccess)
                return Ok(clientQueryResult.Range);
            else return BadRequest(ModelState);
        }

        [HttpGet(ApiRoutes.PaymentRoutes.GetSinge)]
        public async Task<IActionResult> GetSingle(int paymentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentGetAllRequest = new PaymentGetSingleRequest(paymentId);
            var clientQueryResult = await _mediator.Send(paymentGetAllRequest);
            var jsonResult = clientQueryResult.ToJsonContent();

            if (clientQueryResult.IsSuccess)
                return Ok(clientQueryResult.Entity);
            else return BadRequest(ModelState);
        }

        [HttpGet(ApiRoutes.PaymentRoutes.GetLastRange)]
        public async Task<IActionResult> GetLast(int lastPageWidth)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentLastRequest = new PaymentGetLastRequest(lastPageWidth);
            var clientQueryResult = await _mediator.Send(paymentLastRequest);
            var jsonResult = clientQueryResult.ToJsonContent();

            if (clientQueryResult.IsSuccess)
                return Ok(clientQueryResult.Entity);
            else return BadRequest(ModelState);
        }
    }
}
