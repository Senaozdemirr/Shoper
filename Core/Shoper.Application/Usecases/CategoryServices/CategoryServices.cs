using Shoper.Application.Dtos.CategoryDtos;
using Shoper.Application.Interfaces;
using Shoper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Usecases.CategoryServices
{
    public class CategoryServices : ICategoryServices       //servisi arayuze bagladim
    {
        private readonly IRepository<Category> _repository;

        public CategoryServices(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto model)
        {
            await _repository.CreateAsync(new Category
            {
                CategoryName = model.CategoryName,      
            });
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category= await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(category);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var categories  = await _repository.GetAllAsync();
            return categories.Select(x=> new ResultCategoryDto      //category hepsini dönüyor, tek tek seçecegimiz icin x kullandım.
            {
                CategoryId = x.CategoryId,          
                CategoryName = x.CategoryName,
            }).ToList();
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            var newCategory = new GetByIdCategoryDto        //yeni kategori olusturdum
            {
                CategoryId = category.CategoryId,       //kategoriyi tanimladim
                CategoryName = category.CategoryName,
            };
            return newCategory;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto model)
        {
            var category = await _repository.GetByIdAsync(model.CategoryId);    //id'yi buluyo
            category.CategoryName = model.CategoryName;                         //degistiriyo
            await _repository.UpdateAsync(category);                            //guncelleme islemini yap.
        }
    }
}
