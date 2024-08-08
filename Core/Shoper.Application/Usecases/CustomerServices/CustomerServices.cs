using Shoper.Application.Dtos.CustomerDtos;
using Shoper.Application.Interfaces;
using Shoper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Usecases.CustomerServices
{
    public class CustomerServices : ICustomerServices
    {
        //db ile baglanti yapaalim
        private readonly IRepository<Customer> _repository;

        public CustomerServices(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            await _repository.CreateAsync(new Customer
            {
                CustomerFirstName = createCustomerDto.CustomerFirstName,
                CustomerLastName = createCustomerDto.CustomerLastName,
                CustomerEmail = createCustomerDto.CustomerEmail
            });
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var values = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(values);

        }

        public async Task<List<ResultCustomerDto>> GetAllCustomerAsync()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new ResultCustomerDto
            {
                CustomerId = x.CustomerId,
                CustomerFirstName = x.CustomerFirstName,
                CustomerLastName = x.CustomerLastName,
                CustomerEmail = x.CustomerEmail,
                Orders = x.Orders,
            }).ToList();
        }

        public async Task<GetByIdCustomerDto> GetByIdCustomerAsync(int id)
        {
            var values = await _repository.GetByIdAsync(id);
            return new GetByIdCustomerDto
            {
                CustomerId = values.CustomerId,
                CustomerFirstName = values.CustomerFirstName,
                CustomerLastName = values.CustomerLastName,
                CustomerEmail = values.CustomerEmail,
                Orders = values.Orders,
            };
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {
            var values = await _repository.GetByIdAsync(updateCustomerDto.CustomerId);
            values.CustomerFirstName = updateCustomerDto.CustomerFirstName;
            values.CustomerLastName = updateCustomerDto.CustomerLastName;
            values.CustomerEmail = updateCustomerDto.CustomerEmail;
            // values.Orders = updateCustomerDto.Orders;
            await _repository.UpdateAsync(values);
        }
    }
}
