using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Order.Api.Managers;
using Order.Shared;

namespace Order.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IBus _bus;

    public OrdersController(IBus bus)
    {
        _bus = bus;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrder createOrder,
        [FromServices] OrderStore store
    )
    {

        OrderModel order = new OrderModel(Guid.NewGuid(), createOrder.Products);

        store.Orders.Add(order);

        await _bus.Publish(order);
        return Ok(order.Id);
    }


    [HttpGet("{id}/price")]
    public IActionResult GetOrderPrice(Guid id, [FromServices] PriceStore priceStore)
    {
        var orderPrice = priceStore.Prices.FirstOrDefault(p => p.OrderId == id);
        if (orderPrice == null)
        {
            return NotFound();
        }
        return Ok(orderPrice);
    }

}