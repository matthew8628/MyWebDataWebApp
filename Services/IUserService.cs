using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> CreateUser(User NewUser);

        Task<User?> GetUserByIdAsync(int id);

        Task<User> UpdateUserAsync(User user);

        Task DeleteUserAsync(int id);
    }
}