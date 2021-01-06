using System;
using System.Threading.Tasks;
using _.Models;
using Microsoft.EntityFrameworkCore;
using TempWeb.Data;
using TempWeb.Models;

namespace _.Data.Admin
{
    public class AddActions: IAddActions
    {
        private DataContext _context;

        public AddActions(DataContext context)
        {
            _context = context;
        }


        public async Task<Cuisine> AddCuisine(Cuisine cousine)
       {
           try
           {
               await _context.Cuisines.AddAsync(cousine);
               await _context.SaveChangesAsync();
           }
           catch (Exception e)
           {
               return null;
           }
           
           return cousine;
        }

        public async Task<Product> AddProduct(Product product)
        {
            var productCategory = await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == product.ProductCategoryId);
            product.ProductCategory = productCategory;
            
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
            return product;
        }

        public async Task<ProductCategory> AddProductCategory(ProductCategory productCategory)
        {
            try
            {
                await _context.ProductCategories.AddAsync(productCategory);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
            return productCategory;
        }
        

        public async Task<Ingridient> AddIncrident(Ingridient ingridient)
        {

            try
            {
                await _context.Ingridients.AddAsync(ingridient);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            return ingridient;
        }

        public async Task<IngridientCategory> AddIngridientCategory(IngridientCategory ingridientCategory)
        {
            try
            {
                await _context.IngridientCategories.AddAsync(ingridientCategory);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e); 
                return null;
            }
            
            return ingridientCategory;
        }
    }
}