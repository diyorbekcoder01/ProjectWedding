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
    public class ClientService : IClientService
    {
        private readonly IGenericRepository<Client> clientRepository = new GenericRepository<Client>();
        public async Task<ResponseClient> CreateAsync(ClientCreationDTO client)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseClient> DeleteAsync(long id)
        {
            // model o'zgaruvchisiga funksiya orqali olingan element o'zlashtirildi
            var model = await clientRepository.GetByIdAsync(id);
            // model checking isNull
            if (model is null)
            {
                return new ResponseClient()
                {
                    StatusCode = 404,
                    Message = "Client not found!",
                    isOk = false,
                    Client = null
                };
            }
            // model is not null => section
            // model o'chirilmoqda (with DeleteAsync())
            await clientRepository.DeleteAsync(id);
            return new ResponseClient()
            {
                StatusCode = 200,
                isOk = true,
                Message = "Success",
                Client = null
            };

        }

        public async Task<ListResponseClient> GetAllAsync()
        {
            var clients = await clientRepository.GetAllAsync();
            return new ListResponseClient()
            {
                StatusCode = 200,
                Message = "Success",
                Clients = clients
            };
        }

        public async Task<ResponseClient> GetByIdAsync(long id)
        {
            var model = await clientRepository.GetByIdAsync(id);
            if (model is null)
            {
                return new ResponseClient()
                {
                    StatusCode = 404,
                    Message = "Client not found",
                    isOk = false,
                    Client = null
                };
            }
            return new ResponseClient()
            {
                StatusCode = 200,
                Message = "Success",
                isOk = true,
                Client = model
            };
        }

        public async Task<ResponseClient> GetByNameAsync(string name)
        {
            var models = await clientRepository.GetAllAsync();
            var model = models.FirstOrDefault(x => x.firstName == name);
            if (model is null)
            {
                return new ResponseClient()
                {
                    StatusCode = 404,
                    Message = "Client not found",
                    isOk = false,
                    Client = null
                };
            }
            return new ResponseClient()
            {
                StatusCode = 200,
                Message = "Success",
                isOk = true,
                Client = model
            };
        }

        public async Task<ResponseClient> UpdateAsync(long id, ClientCreationDTO client)
        {
            var model = await clientRepository.GetByIdAsync(id);
            if (model is null)
            {
                return new ResponseClient()
                {
                    StatusCode = 404,
                    Message = "Client not found",
                    isOk = false,
                    Client = null
                };
            }
            var result = new Client()
            {
                dateOfBirth = client.dateOfBirth,
                email = client.email,
                firstName = client.firstName,
                lastName = client.lastName,
                Guests = client.Guests,
                Orders = client.Orders,
                password = client.password,
                phone = client.phone                 
            };
            var updatedClient = await clientRepository.UpdateAsync(model);
            return new ResponseClient()
            {
                StatusCode = 200,
                Message = "Success",
                isOk = true,
                Client = updatedClient
            };
        }
    }
}
