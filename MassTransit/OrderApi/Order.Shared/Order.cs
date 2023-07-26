namespace Order.Shared;

    public record CreateOrder(List<ProductModel> Products);

    public record OrderModel(Guid Id, List<ProductModel> Products);

    public record ProductModel(int Id, string Name, long Price);

    public record PriceModel(Guid OrderId, long TotalPrice);
