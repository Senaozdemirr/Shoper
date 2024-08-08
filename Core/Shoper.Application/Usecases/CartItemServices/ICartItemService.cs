using Shoper.Application.Dtos.CartItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Usecases.CartItemServices
{
    public interface ICartItemService
    {
        Task<List<ResultCartItemDto>> GetAllCartItemAsync(); //bütün CartItemlari almak icin
        Task<GetByIdCartItemDto> GetByIdCartItemAsync(int id);
        Task CreateCartItemAsync(CreateCartItemDto model);  //model gonderilecek
        Task UpdateCartItemAsync(UpdateCartItemDto model);
        Task DeleteCartItemAsync(int id);
        Task<List<ResultCartItemDto>> GetByCartIdCartItemAsync(int cartId);
    }
}
