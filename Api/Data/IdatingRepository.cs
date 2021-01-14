using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TempWeb.Models;

namespace _.Data
{
    public interface IdatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int userId);

        Task<bool> SaveAll();
    } 
}