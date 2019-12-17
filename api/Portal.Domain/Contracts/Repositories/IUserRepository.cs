using System.Threading.Tasks;
using Portal.Domain.Models;

namespace Portal.Domain.Contracts.Repositories {
    public interface IUserRepository : IBaseRepository<User>{
        Task<User> GetUserByEmailAsync (string email);
        Task<User> GetUserByEmailAndPasswordAsync (string email, string password);
    }
}