using CostSplitterAPI.DTO;
using CostSplitterAPI.Models;

namespace CostSplitterAPI.Services.Users
{
    public interface IUserService
    {
        Task<IResult> Login(UserDTO user);

        Task<IResult> AddUser(User user);
        Task<IResult> GetAllUsers();
    }
}
