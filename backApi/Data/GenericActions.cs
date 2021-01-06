using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TempWeb.Data;

namespace _.Data
{
    public class GenericActions: IGenericActions
    {
        private DataContext _context;

        public GenericActions(DataContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<T>> GetAll<T>() where T : class 
        {
            var infos = await _context.Set<T>().ToListAsync();
            return infos;
        }

        public async Task<T> GetOneElement<T>(int id) where T : class
        {
            var oneElement = await _context.Set<T>().FindAsync(id);
            return oneElement;
        }
    }
}