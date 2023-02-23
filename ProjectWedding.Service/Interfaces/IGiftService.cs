using ProjectWedding.Service.DTOs;
using ProjectWedding.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWedding.Service.Interfaces
{
    public interface IGiftService
    {
        Task<ResponseGift> CreateAsync(GiftCreationDTO gift);
        Task<ResponseGift> UpdateAsync(long id, GiftCreationDTO gift);
        Task<ResponseGift> DeleteAsync(long id);
        Task<ResponseGift> GetByIdAsync(long id);
        Task<ResponseGift> GetByNameAsync(string name);
        Task<ListResponseGift> GetAllAsync();
    }
}
