using Order.Shared;

namespace Order.Api.Managers;

public class OrderStore
{
    public List<OrderModel> Orders { get; set; }

    public OrderStore()
    {
        Orders = new List<OrderModel>();
    }
}

public class PriceStore
{
    public List<PriceModel> Prices { get; set; }

    public PriceStore()
    {
        Prices = new List<PriceModel>();
    }
}