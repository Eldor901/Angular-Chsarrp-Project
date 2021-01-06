using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace _.Dtos.AddActions
{
    public class addIngridientDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string name { get; set; }
        [Required]
        public IFormFile? imgurl { get; set; }
        [Required]
        public string inridientCategoryName { get; set; }
        
        public string ? productName { get; set; }
        
    }
}