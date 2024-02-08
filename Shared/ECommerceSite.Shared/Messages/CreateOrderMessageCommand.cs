using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSite.Shared.Messages
{
    public class CreateOrderMessageCommand
    {
        public CreateOrderMessageCommand()
        {
            OrderItems = new List<OrderItem>();
        }
        public string BuyerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string? Township { get; set; }
        public string? Neighbourhood { get; set; }
        public string? Street { get; set; }
        public string? Gait { get; set; }
        public string? Block { get; set; }
        public int Number { get; set; }
        public int? ZipCode { get; set; }
    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
    }
}
