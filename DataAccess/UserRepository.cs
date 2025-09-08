using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {
        public readonly WebAppContext _context;

        public UserRepository(WebAppContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }
        public async Task AddUserAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
