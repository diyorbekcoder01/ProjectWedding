using ProjectWedding.Service.DTOs;
using ProjectWedding.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWedding.Service.Interfaces
{
    public interface IGuestService
    {
        Task<ResponseGuest> CreateAsync(GuestCreationDTO guest);
        Task<ResponseGuest> UpdateAsync(long id, GuestCreationDTO guest);
        Task<ResponseGuest> DeleteAsync(long id);
        Task<ResponseGuest> GetByIdAsync(long id);
        Task<ResponseGuest> GetByNameAsync(string name);
        Task<ListResponseGuest> GetAllAsync();
    }
}
