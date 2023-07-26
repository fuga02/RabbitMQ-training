using MassTransit;
using Order.Shared;
using Price.Api.Managers;

namespace Price.Api.Consumers;

public class OrderConsumer:IConsumer<OrderModel>
{
    private readonly IPriceManager _priceManager;

    public OrderConsumer(IPriceManager priceManager)
    {
        _priceManager = priceManager;
    }

    public async Task Consume(ConsumeContext<OrderModel> context)
    {
        OrderModel order = context.Message;
        PriceModel price = _priceManager.Calculate(order);

        await context.Publish(price);
    }
}