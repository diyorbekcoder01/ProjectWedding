using ProjectWedding.Data.IRepositories;
using ProjectWedding.Data.Repositories;
using ProjectWedding.Domain.Entities;
using ProjectWedding.Service.DTOs;
using ProjectWedding.Service.Helpers;
using ProjectWedding.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWedding.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> productRepository = new GenericRepository<Product>();
        public Task<ResponseProduct> CreateAsync(ProductCreationDTO product)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseProduct> DeleteAsync(long id)
        {
            // model o'zgaruvchisiga funksiya orqali olingan element o'zlashtirildi
            var model = await productRepository.GetByIdAsync(id);
            // model checking isNull
            if (model is null)
            {
                return new ResponseProduct()
                {
                    StatusCode = 404,
                    Message = "Product not found!",
                    isOk = false,
                    Product = null
                };
            }
            // model is not null => section
            // model o'chirilmoqda (with DeleteAsync())
            await productRepository.DeleteAsync(id);
            return new ResponseProduct()
            {
                StatusCode = 200,
                isOk = true,
                Message = "Success",
                Product = null
            };
        }

        public async Task<ListResponseProduct> GetAllAsync()
        {
            var products = await productRepository.GetAllAsync();
            return new ListResponseProduct()
            {
                StatusCode = 200,
                Message = "Success",
                Products = products
            };
        }

        public async Task<ResponseProduct> GetByIdAsync(long id)
        {
            var model = await productRepository.GetByIdAsync(id);
            if (model is null)
            {
                return new ResponseProduct()
                {
                    StatusCode = 404,
                    Message = "Guest not found",
                    isOk = false,
                    Product = null
                };
            }
            return new ResponseProduct()
            {
                StatusCode = 200,
                Message = "Success",
                isOk = true,
                Product = model
            };
        }

        public Task<ResponseProduct> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseProduct> UpdateAsync(long id, ProductCreationDTO product)
        {
            var model = await productRepository.GetByIdAsync(id);
            if (model is null)
            {
                return new ResponseProduct()
                {
                    StatusCode = 404,
                    Message = "Gift not found",
                    isOk = false,
                    Product = null
                };
            }
            var result = new Product()
            {
                UpdatedAt = DateTime.Now,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price 
            };
            var updatedProduct = await productRepository.UpdateAsync(model);
            return new ResponseProduct()
            {
                StatusCode = 200,
                Message = "Success",
                isOk = true,
                Product = updatedProduct
            };
        }
    }
}
