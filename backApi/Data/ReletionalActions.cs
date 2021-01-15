using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _.Models;
using Microsoft.EntityFrameworkCore;
using TempWeb.Data;

namespace _.Data
{
    public class ReletionalActions : IReletionalActions 
    {
        private DataContext _context;

        public ReletionalActions(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ProductCategory>> CuisineAllProductsInCategory(int cusineId)
        {
            List<ProductCategory> productCategory = new List<ProductCategory>();

            var id = await _context.Cuisines.FirstOrDefaultAsync(x => x.Id == cusineId);
            
            var prod = await _context.ProductCategories.Include(b => b.Products).Where(x => x.Products.Any(i=> i.CuisineId == id.Id)).ToListAsync();


            return prod;
        }

        public async Task<List<IngridientCategory>> ProductAllIngridentsInCategory(string productId)
        {
            List<IngridientCategory> ingridientCategory = new List<IngridientCategory>();

            var IngridientOfProduct = await _context.Ingridients.Where(x => x.name == productId).ToListAsync();
            
            foreach (var Ip in IngridientOfProduct)
            {
                var ingridient  = await _context.IngridientCategories.Where(x => x.Id == Ip.Id).ToListAsync();
                
                ingridientCategory.AddRange(ingridient);
            }

            return ingridientCategory;
        }

        public int RetId(int id)
        {
            return id;
        }
    }
}