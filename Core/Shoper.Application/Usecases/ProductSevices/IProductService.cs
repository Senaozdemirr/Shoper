﻿using Shoper.Application.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Usecases.ProductSevices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync(); //bütün Productlari almak icin
        Task<GetByIdProductDto> GetByIdProductAsync(int id);
        Task CreateProductAsync(CreateProductDto model);  //model gonderilecek
        Task UpdateProductAsync(UpdateProductDto model);
        Task DeleteProductAsync(int id);
        Task<List<ResultProductDto>> GetProductTake(int sayi);
        Task<List<ResultProductDto>> GetProductByCategory(int categoryId);
        Task<List<ResultProductDto>> GetProductByPrice(decimal minprice, decimal maxprice);
        Task<List<ResultProductDto>> GetProductBySearch(string search);
    }
}
