using System.Linq;
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

        public async Task<Cuisine> DeleteCusine(int id)
        {
            Cuisine cusine = await _context.Cuisines.Where(x => x.Id == id).FirstOrDefaultAsync();
            
            _context.Cuisines.Remove(cusine);
            await _context.SaveChangesAsync();
            return cusine;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            Product product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}