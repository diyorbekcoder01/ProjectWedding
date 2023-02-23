using ProjectWedding.Service.DTOs;
using ProjectWedding.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWedding.Service.Interfaces
{
    public interface IClientService
    {
        Task<ResponseClient> CreateAsync(ClientCreationDTO client);
        Task<ResponseClient> UpdateAsync(long id, ClientCreationDTO client);
        Task<ResponseClient> DeleteAsync(long id);
        Task<ResponseClient> GetByIdAsync(long id);
        Task<ResponseClient> GetByNameAsync(string name);
        Task<ListResponseClient> GetAllAsync();
    }
}
