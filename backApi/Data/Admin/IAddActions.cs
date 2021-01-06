using System.Threading.Tasks;
using _.Models;
using TempWeb.Models;

namespace _.Data.Admin
{
    public interface IAddActions
    {
        Task<Cuisine> AddCuisine(Cuisine cousine);
        Task<Product> AddProduct(Product product);

        Task<ProductCategory> AddProductCategory(ProductCategory productCategory);
        Task<Ingridient> AddIncrident(Ingridient ingridient);

        Task<IngridientCategory> AddIngridientCategory(IngridientCategory ingridientCategory);

    }
}