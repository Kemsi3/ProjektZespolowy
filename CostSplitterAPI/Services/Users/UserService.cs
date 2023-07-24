using CostSplitterAPI.Data;
using CostSplitterAPI.DTO;
using CostSplitterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CostSplitterAPI.Services.Users
{
    public class UserService : IUserService
    {

        public readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<IResult> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Results.Created($"/user/{user.UserId}", user);
        }

        public async Task<IResult> Login(UserDTO user)
        {
            User userFound = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (userFound == null)
            {
                return Results.NotFound("Bad login or password");
            }

            return Results.Ok(userFound);

        }

        public async Task<IResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Results.Ok(users);
        }
    }
}
