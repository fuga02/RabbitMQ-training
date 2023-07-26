using MassTransit;
using Order.Api.Managers;
using Order.Shared;

namespace Order.Api.Consumers;

public class PriceConsumer:IConsumer<PriceModel>
{
    private readonly PriceStore _priceStore;

    public PriceConsumer(PriceStore priceStore)
    {
        _priceStore = priceStore;
    }

    public Task Consume(ConsumeContext<PriceModel> context)
    {
        _priceStore.Prices.Add(context.Message);
        return Task.CompletedTask;
    }
}