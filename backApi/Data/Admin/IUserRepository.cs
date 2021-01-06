using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TempWeb.Models;

namespace _.Data.Admin
{
    public interface IUserRepository
    {
        Task<User> ChangeUserRole(string user, string role);
        Task<bool> DeleteUser(string user);
        Task<IEnumerable<User>> AllUsers();
    }
}