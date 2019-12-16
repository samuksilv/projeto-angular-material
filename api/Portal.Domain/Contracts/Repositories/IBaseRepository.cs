using System;
using System.Threading.Tasks;
using Portal.Domain.Models;

namespace Portal.Domain.Contracts.Repositories  {
    public interface IBaseRepository<T> where T : BaseModel {
        Task<T> SaveAsync (T model);
        Task<T> UpdateAsync (T model);
        Task DeleteAsync (T model);
        Task<T> GetByIdAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}