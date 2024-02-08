using ECommerceSite.Services.Catalog.DataAccess.Data;
using ECommerceSite.Services.Catalog.Models.Models;
using ECommerceSite.Services.Order.Domain.OrderAggregate;
using ECommerceSite.Services.Order.Infrastructere;
using ECommerceSite.Shared.Messages;
using MassTransit;
using MassTransit.Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MassTransit.MessageHeaders;

namespace ECommerceSite.Services.Catalog.Application.Consumers
{
    public class CreateOrderMessageCommandConsumers : IConsumer<CreateOrderMessageCommand>
    {
        private readonly OrderDbContext _orderDbContext;
        private readonly ApplicationDbContext _applicationDbContext;

        public CreateOrderMessageCommandConsumers(OrderDbContext orderDbContext, ApplicationDbContext applicationDbContext)
        {
            _orderDbContext = orderDbContext;
            _applicationDbContext = applicationDbContext;
        }

        public async Task Consume(ConsumeContext<CreateOrderMessageCommand> context)
        {
            int productId = 0;
            int newQuantity = 0;
            context.Message.OrderItems.ForEach(x =>
            {
                productId = x.ProductId;
                newQuantity = x.Quantity;
            });

            var quantityList = _applicationDbContext.ProductStock.Where(x => x.ProductId == productId).ToList();
            //List<object> quant2ityList = new { _applicationDbContext.ProductStock.SelectMany(x => x.ProductId.Equals(productId)) };
            var quantity = _applicationDbContext.ProductStock.Where(x => x.ProductId.Equals(productId)).Sum(x => x.Stock);

            if (newQuantity > 0 && newQuantity <= quantity)
            {
                for(int i = 0; i < quantityList.Count; i++)
                {
                    if (quantityList[i].Stock <= newQuantity) {
                       
                        newQuantity = newQuantity - quantityList[i].Stock;
                        quantityList[i].Stock = 0;

                        
                        await _applicationDbContext.SaveChangesAsync();
                    }
                    else if(quantityList[i].Stock >= newQuantity)
                    {
                        quantityList[i].Stock = quantityList[i].Stock - newQuantity;
                        await _applicationDbContext.SaveChangesAsync();
                        break;
                    }
                    
                }
            }
            else
            {

            }
        }
    }

}
