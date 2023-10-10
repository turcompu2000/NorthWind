using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Presenters;
using NorthWind.UseCases.CreateOrder;
using NorthWind.UseCasesDTOs.CreateOrder;

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly IMediator Mediator;

        public OrderController(IMediator mediator) =>
            Mediator = mediator;

        [HttpPost("create-order")]

        public async Task<string> CreateOrder(
            CreateOrderParams orderparams)
        {
            CreateOrderPresenter Presenter = new CreateOrderPresenter();
            await Mediator.Send(new CreateOrderInputPort(orderparams, Presenter));
            return Presenter.Content;
        }
    }
}