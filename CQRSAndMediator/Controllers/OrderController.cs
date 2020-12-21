using CQRSAndMediator.Interfaces.ICommandHandlers;
using CQRSAndMediator.Interfaces.IQueryHandlers;
using CQRSAndMediator.RequestModels.CommandRequestModels;
using CQRSAndMediator.RequestModels.QueryRequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRSAndMediator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("makeorder")]
        public IActionResult MakeOrder([FromBody] MakeOrderRequestModel requestModel)
        {
            var response = _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpPost("addorder")]
        public async Task<IActionResult> AddOrder([FromBody] MakeOrderRequestModel requestModel)
        {
            var response = await _mediator.Send(requestModel);

            return Ok(response);
        }

        [HttpGet("order")]
        public IActionResult OrderDetails([FromQuery] GetOrderByIdRequestModel requestModel)
        {
            var response = _mediator.Send(requestModel);
            return Ok(response);
        }
    }
}