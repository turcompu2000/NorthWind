using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthWind.UseCases.CreateOrder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorthWind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator Mediator;

        public OrderController(IMediator mediator) =>
            Mediator = mediator;

        [HttpPost("create-order")]

        public async Task<ActionResult<int>> CreateOrder(
            CreateOrderInputPort orderparams)
        {
        return await Mediator.Send(orderparams);
        }

        }
}
