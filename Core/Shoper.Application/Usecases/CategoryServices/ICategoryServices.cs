using Shoper.Application.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Usecases.CategoryServices
{
    public interface ICategoryServices
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync(); //bütün kategorileri almak icin
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id);
        Task CreateCategoryAsync(CreateCategoryDto model);  //model gonderilecek
        Task UpdateCategoryAsync(UpdateCategoryDto model);
        Task DeleteCategoryAsync(int id);
    }
}
