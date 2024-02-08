using ECommerceSite.Services.Order.Domain.Core;

namespace ECommerceSite.Services.Order.Domain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public Decimal Price { get; private set; }

        public OrderItem()
        {
        }

        public OrderItem(int productId, string productName, decimal price, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }

        public void UpdateOrderItem(string productName, decimal price, int quantity )
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }
    }
}