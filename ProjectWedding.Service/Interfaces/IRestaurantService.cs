using ProjectWedding.Service.DTOs;
using ProjectWedding.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWedding.Service.Interfaces
{
    public interface IRestaurantService
    {
        Task<ResponseRestaurant> CreateAsync(RestaurantCreationDTO restaurant);
        Task<ResponseRestaurant> UpdateAsync(long id, RestaurantCreationDTO restaurant);
        Task<ResponseRestaurant> DeleteAsync(long id);
        Task<ResponseRestaurant> GetByIdAsync(long id);
        Task<ResponseRestaurant> GetByNameAsync(string name);
        Task<ListResponseRestaurant> GetAllAsync();
    }
}
