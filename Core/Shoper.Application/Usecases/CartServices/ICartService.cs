using Shoper.Application.Dtos.CartDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Usecases.CartServices
{
    public interface ICartService
    {
        Task<List<ResultCartDto>> GetAllCartAsync(); //bütün Cartlari almak icin
        Task<GetByIdCartDto> GetByIdCartAsync(int id);
        Task CreateCartAsync(CreateCartDto model);  //model gonderilecek
        Task UpdateCartAsync(UpdateCartDto model);
        Task DeleteCartAsync(int id);
        Task UpdateTotalAmount(int cartId, decimal totalAmount);
    }
}
