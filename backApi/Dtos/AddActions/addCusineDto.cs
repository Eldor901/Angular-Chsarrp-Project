using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace _.Dtos.AddActions
{
    public class addCusineDto
    {
        [Required]
        public string name { get; set;}
        [Required]
        public IFormFile imgurl { get; set; }
        [Required]
        public string desc { get; set; }
        
        public int? userId  { get; set; }
    }
}