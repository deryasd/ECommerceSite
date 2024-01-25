using ECommerceSite.Services.Order.Application.Dtos;
using ECommerceSite.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSite.Services.Order.Application.Commands
{
    public class CreateOrderCommand : IRequest<Response<CreatedOrderDto>>
    {
            [Required]
            public string BuyerId { get; set; }

            [Required]
            public List<OrderItemDto> OrderItems { get; set; }

            [Required]
            public AddressDto Address { get; set; }
    }
}