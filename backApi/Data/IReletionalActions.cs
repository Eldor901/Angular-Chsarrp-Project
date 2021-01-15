using System.Collections.Generic;
using System.Threading.Tasks;
using _.Models;

namespace _.Data
{
    public interface IReletionalActions
    {
        Task<List<ProductCategory>> CuisineAllProductsInCategory(int cusineId);
        Task<List<IngridientCategory>> ProductAllIngridentsInCategory(string productId);
        
        int RetId(int id);
    }
}