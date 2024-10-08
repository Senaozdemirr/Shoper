﻿using Shoper.Application.Dtos.ProductDtos;
using Shoper.Application.Interfaces;
using Shoper.Application.Interfaces.IProductsRepository;
using Shoper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Usecases.ProductSevices
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IProductsRepository _productsRepository;

        public ProductService(IRepository<Product> repository, 
            IProductsRepository productsRepository)
        {
            _repository = repository;
            _productsRepository = productsRepository;
        }

        public async Task CreateProductAsync(CreateProductDto model)
        {
            await _repository.CreateAsync(new Product
            {
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                ProductPrice = model.ProductPrice,
                ProductStock = model.ProductStock,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId
            });
        }

        public async Task DeleteProductAsync(int id)
        {
            var values = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(values);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new ResultProductDto
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                ProductPrice = x.ProductPrice,
                ProductStock = x.ProductStock,
                ImageUrl = x.ImageUrl,
                CategoryId = x.CategoryId
            }).ToList();
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(int id)
        {
            var values = await _repository.GetByIdAsync(id);
            var result = new GetByIdProductDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductDescription = values.ProductDescription,
                ProductPrice = values.ProductPrice,
                ProductStock = values.ProductStock,
                ImageUrl = values.ImageUrl,
                CategoryId = values.CategoryId
            };
            return result;
        }

        public async Task<List<ResultProductDto>> GetProductByCategory(int categoryId)
        {
            var values = await _productsRepository.GetProductByCategory(categoryId);
            return values.Select(x => new ResultProductDto
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                ProductPrice = x.ProductPrice,
                ProductStock = x.ProductStock,
                ImageUrl = x.ImageUrl,
                CategoryId = x.CategoryId
            }).ToList();
        }

        public async Task<List<ResultProductDto>> GetProductByPrice(decimal minprice, decimal maxprice)
        {
            var values=await _productsRepository.GetProductByPriceFilter(minprice, maxprice);
            return values.Select(x => new ResultProductDto
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                ProductPrice = x.ProductPrice,
                ProductStock = x.ProductStock,
                ImageUrl = x.ImageUrl,
                CategoryId = x.CategoryId
            }).ToList();
        }

        public async Task<List<ResultProductDto>> GetProductBySearch(string search)
        {
            var values = await _productsRepository.GetProductBySearch(search);
            return values.Select(x => new ResultProductDto
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                ProductPrice = x.ProductPrice,
                ProductStock = x.ProductStock,
                ImageUrl = x.ImageUrl,
                CategoryId = x.CategoryId
            }).ToList();
        }

        public async Task<List<ResultProductDto>> GetProductTake(int sayi)
        {
            var values = await _repository.GetTakeAsync(sayi);
            return values.Select(x => new ResultProductDto
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                ProductPrice = x.ProductPrice,
                ProductStock = x.ProductStock,
                ImageUrl = x.ImageUrl,
                CategoryId = x.CategoryId
            }).ToList();
        }

        public async Task UpdateProductAsync(UpdateProductDto model)
        {
            var values= await _repository.GetByIdAsync(model.ProductId);
            values.ProductName = model.ProductName;
            values.ProductDescription = model.ProductDescription;   
            values.ProductPrice = model.ProductPrice;
            values.ProductStock = model.ProductStock;
            values.ImageUrl = model.ImageUrl;
            values.CategoryId = model.CategoryId;
            await _repository.UpdateAsync(values);

        }
    }
}
