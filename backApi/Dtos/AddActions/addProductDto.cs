using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace _.Dtos.AddActions
{
    public class addProductDto
    {
        [Required]
        public string name { get; set; }
        [Required]
        public IFormFile imgurl { get; set; }
        [Required]
        public float  price { get; set; }
        
        public string  productCategoryName { get; set; }
        
        public string? cousineName { get; set; } 
    }
}