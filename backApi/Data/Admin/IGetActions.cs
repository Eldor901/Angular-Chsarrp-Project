using System.Threading.Tasks;
using _.Models;
using TempWeb.Models;

namespace _.Data.Admin
{
    public interface IGetActions
    {
        Task<Cuisine> GetIdCousine(string name);
        Task<ProductCategory> GetIdProductCategory(string name);
        Task<Product> GetIdProduct(string name);
        Task<IngridientCategory> GetIdIngridient(string name);

        Task<Cuisine> DeleteCusine(int  id);

        Task<Product> DeleteProduct(int id);
    }
}