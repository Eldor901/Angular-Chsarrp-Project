using System.Threading.Tasks;
using _.Models;
using Microsoft.EntityFrameworkCore;
using TempWeb.Data;
using TempWeb.Models;

namespace _.Data.Admin
{
    public class GetActions : IGetActions
    {
        private DataContext _context;

        public GetActions(DataContext context)
        {
            _context = context;
        }
        
        
        public async Task<Cuisine> GetIdCousine(string name)
        {
            var id = await _context.Cuisines.FirstOrDefaultAsync(t => t.name == name);
            
            return id;
        }

        public  async Task<ProductCategory> GetIdProductCategory(string name)
        {
            var id = await _context.ProductCategories.FirstOrDefaultAsync(t => t.name == name);
            
            return id;
        }

        public async Task<Product> GetIdProduct(string name)
        {
            var id = await _context.Products.FirstOrDefaultAsync(t => t.name == name);
            
            return id;
        }

        public async Task<IngridientCategory> GetIdIngridient(string name)
        {
            var id = await _context.IngridientCategories.FirstOrDefaultAsync(t => t.name == name);
            
            return id;
        }
    }
}