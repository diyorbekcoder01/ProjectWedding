using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWedding.Data.IRepositories
{
    public interface IGenericRepository<TResult>
    {
        Task<TResult> CreateAsync(TResult value);
        Task<TResult> UpdateAsync(TResult value);
        Task<bool> DeleteAsync(long id);
        Task<TResult> GetByIdAsync(long id);
        
        Task<List<TResult>> GetAllAsync();
    }
}
