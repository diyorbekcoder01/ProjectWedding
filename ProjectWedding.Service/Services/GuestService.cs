using ProjectWedding.Data.IRepositories;
using ProjectWedding.Data.Repositories;
using ProjectWedding.Domain.Entities;
using ProjectWedding.Service.DTOs;
using ProjectWedding.Service.Helpers;
using ProjectWedding.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWedding.Service.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGenericRepository<Guest> guestRepository = new GenericRepository<Guest>();
        public Task<ResponseGuest> CreateAsync(GuestCreationDTO guest)
        { 
            throw new NotImplementedException();
        }

        public async Task<ResponseGuest> DeleteAsync(long id)
        {
            // model o'zgaruvchisiga funksiya orqali olingan element o'zlashtirildi
            var model = await guestRepository.GetByIdAsync(id);
            // model checking isNull
            if (model is null)
            {
                return new ResponseGuest()
                {
                    StatusCode = 404,
                    Message = "Guest not found!",
                    isOk = false,
                    Guest = null
                };
            }
            // model is not null => section
            // model o'chirilmoqda (with DeleteAsync())
            await guestRepository.DeleteAsync(id);
            return new ResponseGuest()
            {
                StatusCode = 200,
                isOk = true,
                Message = "Success",
                Guest = null
            };
        }

        public async Task<ListResponseGuest> GetAllAsync()
        {
            var guests = await guestRepository.GetAllAsync();
            return new ListResponseGuest()
            {
                StatusCode = 200,
                Message = "Success",
                Guests = guests
            };
        }

        public async Task<ResponseGuest> GetByIdAsync(long id)
        {
            var model = await guestRepository.GetByIdAsync(id);
            if (model is null)
            {
                return new ResponseGuest()
                {
                    StatusCode = 404,
                    Message = "Guest not found",
                    isOk = false,
                    Guest = null
                };
            }
            return new ResponseGuest()
            {
                StatusCode = 200,
                Message = "Success",
                isOk = true,
                Guest = model
            };
        }

        public Task<ResponseGuest> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseGuest> UpdateAsync(long id, GuestCreationDTO guest)
        {
            var model = await guestRepository.GetByIdAsync(id);
            if (model is null)
            {
                return new ResponseGuest()
                {
                    StatusCode = 404,
                    Message = "Gift not found",
                    isOk = false,
                    Guest = null
                };
            }
            var result = new Guest()
            {
                UpdatedAt = DateTime.Now,
                lastName = model.lastName,
                firstName = model.firstName,
                Password = model.Password,
                Email = model.Email, 
                Gifts = model.Gifts,                
            };
            var updatedGuest = await guestRepository.UpdateAsync(model);
            return new ResponseGuest()
            {
                StatusCode = 200,
                Message = "Success",
                isOk = true,
                Guest = updatedGuest
            };
        }
    }
}
