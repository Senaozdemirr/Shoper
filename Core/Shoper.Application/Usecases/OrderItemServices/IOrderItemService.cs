using Shoper.Application.Dtos.OrderItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Usecases.OrderItemServices
{
    public interface IOrderItemService
    {
        Task<List<ResultOrderItemDto>> GetAllOrderItemAsync(); //bütün OrderItemlari almak icin
        Task<GetByIdOrderItemDto> GetByIdOrderItemAsync(int id);
        Task CreateOrderItemAsync(CreateOrderItemDto model);  //model gonderilecek
        Task UpdateOrderItemAsync(UpdateOrderItemDto model);
        Task DeleteOrderItemAsync(int id);
    }
}
