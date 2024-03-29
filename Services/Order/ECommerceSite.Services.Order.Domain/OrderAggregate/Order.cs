﻿using ECommerceSite.Services.Order.Domain.Core;

namespace ECommerceSite.Services.Order.Domain.OrderAggregate
{
    //EF Core features
    // -- Owned Types
    // -- Shadow Property
    // -- Backing Field
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; }

        public Address Address { get; private set; }

        public string BuyerId { get; private set; }

        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order()
        {
        }

        public Order(string buyerId, Address address)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
        }

        public void AddOrderItem(int productId, string productName, decimal price, int quantity)
        {
            var existProduct = _orderItems.Any(x => x.ProductId == productId);

            if (!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, price, quantity);

                _orderItems.Add(newOrderItem);
            }
        }

        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price * x.Quantity);
    }
}