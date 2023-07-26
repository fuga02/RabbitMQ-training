using  Order.Shared;

namespace Price.Api.Managers;


public interface IPriceManager
{
    PriceModel Calculate(OrderModel  order);
}
public class PriceManager:IPriceManager
{
    public PriceModel Calculate(OrderModel model)
    {
        var totalPrice = model.Products.Sum(m => m.Price);
        return new PriceModel(model.Id, totalPrice);
    }
}