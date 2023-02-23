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
    public class RestaurantService : IRestaurantService
    {
        private readonly IGenericRepository<Restaurant> restaurantRepository = new GenericRepository<Restaurant>();
        public Task<ResponseRestaurant> CreateAsync(RestaurantCreationDTO restaurant)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseRestaurant> DeleteAsync(long id)
        {
            // model o'zgaruvchisiga funksiya orqali olingan element o'zlashtirildi
            var model = await restaurantRepository.GetByIdAsync(id);
            // model checking isNull
            if (model is null)
            {
                return new ResponseRestaurant()
                {
                    StatusCode = 404,
                    Message = "Product not found!",
                    isOk = false,
                    Restaurant = null
                };
            }
            // model is not null => section
            // model o'chirilmoqda (with DeleteAsync())
            await restaurantRepository.DeleteAsync(id);
            return new ResponseRestaurant()
            {
                StatusCode = 200,
                isOk = true,
                Message = "Success",
                Restaurant = null
            };
        }

        public async Task<ListResponseRestaurant> GetAllAsync()
        {
            var restaurants = await restaurantRepository.GetAllAsync();
            return new ListResponseRestaurant()
            {
                StatusCode = 200,
                Message = "Success",
                Restaurants = restaurants
            };
        }

        public async Task<ResponseRestaurant> GetByIdAsync(long id)
        {
            var model = await restaurantRepository.GetByIdAsync(id);
            if (model is null)
            {
                return new ResponseRestaurant()
                {
                    StatusCode = 404,
                    Message = "Guest not found",
                    isOk = false,
                    Restaurant = null
                };
            }
            return new ResponseRestaurant()
            {
                StatusCode = 200,
                Message = "Success",
                isOk = true,
                Restaurant = model
            };
        }

        public Task<ResponseRestaurant> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseRestaurant> UpdateAsync(long id, RestaurantCreationDTO restaurant)
        {
            var model = await restaurantRepository.GetByIdAsync(id);
            if (model is null)
            {
                return new ResponseRestaurant()
                {
                    StatusCode = 404,
                    Message = "Gift not found",
                    isOk = false,
                    Restaurant = null
                };
            }
            var result = new Restaurant()
            {
                Price = restaurant.Price,
                Name = restaurant.Name,
                Description = restaurant.Description,
                UpdatedAt = DateTime.Now,
                Email = restaurant.Email,
                availableDays = restaurant.availableDays,
                Capacity = restaurant.Capacity,
                Location = restaurant.Location,
                Products = restaurant.Products,
                Quality = restaurant.Quality 
            };
            var updatedRestaurant = await restaurantRepository.UpdateAsync(model);
            return new ResponseRestaurant()
            {
                StatusCode = 200,
                Message = "Success",
                isOk = true,
                Restaurant = updatedRestaurant
            };
        }
    }
}
