using Shoper.Application.Dtos.CartItemDtos;
using Shoper.Application.Dtos.OrderItemDtos;
using Shoper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public DateTime OrderDate { get; set; }
        //public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        //public string BillingAdress { get; set; }
        public string ShippingAdress { get; set; }
        //public string PaymentMethod { get; set; }
        public int CustomerId { get; set; }
        //public Customer Customer { get; set; }  //bir siparişin bir sahibi olabilir
        public ICollection<CreateOrderItemDto> OrderItems { get; set; }
    }
}
