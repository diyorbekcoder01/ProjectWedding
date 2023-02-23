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
    public class GiftService : IGiftService
    {
        private readonly IGenericRepository<Gift> giftRepository = new GenericRepository<Gift>(); 
        public Task<ResponseGift> CreateAsync(GiftCreationDTO gift)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseGift> DeleteAsync(long id)
        {
            // model o'zgaruvchisiga funksiya orqali olingan element o'zlashtirildi
            var model = await giftRepository.GetByIdAsync(id);
            // model checking isNull
            if (model is null)
            {
                return new ResponseGift()
                {
                    StatusCode = 404,
                    Message = "Gift not found!",
                    isOk = false,
                    Gift = null
                };
            }
            // model is not null => section
            // model o'chirilmoqda (with DeleteAsync())
            await giftRepository.DeleteAsync(id);
            return new ResponseGift()
            {
                StatusCode = 200,
                isOk = true,
                Message = "Success",
                Gift = null
            };
        }

        public async Task<ListResponseGift> GetAllAsync()
        {
            var gifts = await giftRepository.GetAllAsync();
            return new ListResponseGift()
            {
                StatusCode = 200,
                Message = "Success",
                Gifts = gifts
            };
        }

        public async Task<ResponseGift> GetByIdAsync(long id)
        {
            var model = await giftRepository.GetByIdAsync(id);
            if (model is null)
            {
                return new ResponseGift()
                {
                    StatusCode = 404,
                    Message = "Gift not found",
                    isOk = false,
                    Gift = null
                };
            }
            return new ResponseGift()
            {
                StatusCode = 200,
                Message = "Success",
                isOk = true,
                Gift = model
            };
        }

        public Task<ResponseGift> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseGift> UpdateAsync(long id, GiftCreationDTO gift)
        {
            var model = await giftRepository.GetByIdAsync(id);
            if (model is null)
            {
                return new ResponseGift()
                {
                    StatusCode = 404,
                    Message = "Gift not found",
                    isOk = false,
                    Gift = null
                };
            }
            var result = new Gift()
            {
                 Description = gift.Description,
                 Name = gift.Name,
                 Price = gift.Price,
                 UpdatedAt = DateTime.Now,
            };
            var updatedGift = await giftRepository.UpdateAsync(model);
            return new ResponseGift()
            {
                StatusCode = 200,
                Message = "Success",
                isOk = true,
                Gift = updatedGift
            };
        }
    }
}
