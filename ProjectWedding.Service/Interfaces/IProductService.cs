using ProjectWedding.Service.DTOs;
using ProjectWedding.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWedding.Service.Interfaces
{
    public interface IProductService
    {
        Task<ResponseProduct> CreateAsync(ProductCreationDTO product);
        Task<ResponseProduct> UpdateAsync(long id, ProductCreationDTO product);
        Task<ResponseProduct> DeleteAsync(long id);
        Task<ResponseProduct> GetByIdAsync(long id);
        Task<ResponseProduct> GetByNameAsync(string name);
        Task<ListResponseProduct> GetAllAsync();
    }
}
