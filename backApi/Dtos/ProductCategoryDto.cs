using System.Collections;
using System.Collections.Generic;
using _.Models;

namespace _.Dtos
{
    public class ProductCategoryDto
    {
        public string name { get; set; }
        public List<ProductsForDetailDto> Products{ get; set; }
    }
}