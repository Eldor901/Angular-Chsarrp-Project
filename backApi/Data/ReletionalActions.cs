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
            
            var ProductofCuisine = await _context.Products.Where(x => x.CuisineId == cusineId).ToListAsync();

            foreach (var cp in ProductofCuisine)
            {
                var products = await _context.ProductCategories.Where(x => x.Id == cp.Id).ToListAsync();
                
                productCategory.AddRange(products);
            }

            return productCategory;
        }

        public async Task<List<IngridientCategory>> ProductAllIngridentsInCategory(int productId)
        {
            List<IngridientCategory> ingridientCategory = new List<IngridientCategory>();

            var IngridientOfProduct = await _context.Ingridients.Where(x => x.ProductId == productId).ToListAsync();
            
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