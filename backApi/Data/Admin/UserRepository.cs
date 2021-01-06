using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TempWeb.Data;
using TempWeb.Models;

namespace _.Data.Admin
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;
        private IAuthRepository _authrepo;

        public UserRepository(DataContext context, IAuthRepository authrepo)
        {
            _context = context;
            _authrepo = authrepo;
        }


        public async Task<User> ChangeUserRole(string username, string role)
        {
            var userRole = await _context.Roles.FirstOrDefaultAsync(x => x.name == role);
            
            
            if (userRole != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

                if (user != null)
                {
                    user.Role = userRole;
                    await _context.SaveChangesAsync();
                    
                    return user;
                }
            }
            return null;

        }

        public async Task<bool> DeleteUser(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<User>> AllUsers()
        {
            var users = await _context.Users.Include(u=>u.Role).ToListAsync();

            return users;
        }
        
    }
}