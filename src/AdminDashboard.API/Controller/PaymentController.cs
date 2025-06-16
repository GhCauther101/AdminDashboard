using AdminDashboard.API.Routes;
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

            return Created();
        }

        [HttpPut(ApiRoutes.PaymentRoutes.UpdatePayment)]
        public async Task<IActionResult> Update([FromBody] Payment payment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentUpdateRequest = new PaymentUpdateRequest(payment);

            return Ok();
        }

        [HttpDelete(ApiRoutes.PaymentRoutes.DeletePayment)]
        public async Task<IActionResult> Delete([FromBody] int paymentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentDeleteRequest = new PaymentDeleteRequest(paymentId);

            return Ok();
        }

        [HttpGet(ApiRoutes.PaymentRoutes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentGetAllRequest = new PaymentGetAllRequest();

            return Ok();
        }

        [HttpGet(ApiRoutes.PaymentRoutes.GetSinge)]
        public async Task<IActionResult> GetSingle(int paymentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentGetAllRequest = new PaymentGetSingleRequest(paymentId);

            return Ok();
        }

        [HttpGet(ApiRoutes.PaymentRoutes.GetLastRange)]
        public async Task<IActionResult> GetLast(int lastPageWidth)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paymentGetAllRequest = new PaymentGetSingleRequest(lastPageWidth);

            return Ok();
        }
    }
}
