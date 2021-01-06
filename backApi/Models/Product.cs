using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TempWeb.Models;

namespace _.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        public string name { get; set; }
        
        public string imgurl { get; set; }
       
        public float  price { get; set; }
        
        
        public IList<Ingridient> Ingridients { get; set; }
        public IList<Cart> Carts { get; set; }
        
        public int? ProductCategoryId { get; set; } 
        public ProductCategory ProductCategory{ get; set; }
        public int? CuisineId { get; set; }
        public Cuisine Cuisine{ get; set; }
    }
}