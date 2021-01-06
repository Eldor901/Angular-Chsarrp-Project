using System.Collections.Generic;

namespace _.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string name { get; set; }
        
        public IList<Product> Products{ get; set; }
    }
}