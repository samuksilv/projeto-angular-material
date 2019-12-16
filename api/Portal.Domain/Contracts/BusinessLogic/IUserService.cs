using System.Threading.Tasks;
using Portal.Domain.Dtos.Request;
using Portal.Domain.Dtos.Response;
using Portal.Domain.Models;

namespace Portal.Domain.Contracts.BusinessLogic
{
    public interface IUserService
    {
        Task<UserLoginResponse> LoginAsync (UserLoginRequest request);
        Task<UserRegisterResponse> RegisterAsync (UserRegisterRequest request);
        Task<UserResponse> GetByIdAsync(string id);
    }
}