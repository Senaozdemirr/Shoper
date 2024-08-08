﻿using Shoper.Application.Dtos.CartItemDtos;
using Shoper.Application.Interfaces;
using Shoper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Usecases.CartItemServices
{
    public class CartItemService : ICartItemService
    {
        private readonly IRepository<CartItem> _repository;

        public CartItemService(IRepository<CartItem> repository)
        {
            _repository = repository;
        }

        public async Task CreateCartItemAsync(CreateCartItemDto model)
        {
            var cartItem = new CartItem
            {
                //CartId = model.CartId,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                TotalPrice = model.TotalPrice,
            };
            await _repository.CreateAsync(cartItem);
        }

        public async Task DeleteCartItemAsync(int id)
        {
            var cartItem = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(cartItem);
        }

        public async Task<List<ResultCartItemDto>> GetAllCartItemAsync()
        {
            var cartItems = await _repository.GetAllAsync();
            return cartItems.Select(x => new ResultCartItemDto
            {
                CartId=x.CartId,
                ProductId=x.ProductId,
                Quantity=x.Quantity,
                TotalPrice=x.TotalPrice,
                CartItemId=x.CartItemId,
            }).ToList();
        }

        public Task<List<ResultCartItemDto>> GetByCartIdCartItemAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        public async Task<GetByIdCartItemDto> GetByIdCartItemAsync(int id)
        {
            var cartItem = await _repository.GetByIdAsync(id);
            return new GetByIdCartItemDto
            {
                Quantity = cartItem.Quantity,
                TotalPrice = cartItem.TotalPrice,
                CartItemId = cartItem.CartItemId,
                CartId = cartItem.CartId,
                ProductId = cartItem.ProductId,
            };
        }

        public async Task UpdateCartItemAsync(UpdateCartItemDto model)
        {
            var cartItem = await _repository.GetByIdAsync(model.CartItemId);
            cartItem.Quantity = model.Quantity;
            cartItem.TotalPrice = model.TotalPrice;
            cartItem.ProductId = model.ProductId;
            //cartItem.CartId = model.CartId;
            await _repository.UpdateAsync(cartItem);
        }
    }
}
