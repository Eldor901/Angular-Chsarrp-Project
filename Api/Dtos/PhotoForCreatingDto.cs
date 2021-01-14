using _.Data;
using Microsoft.AspNetCore.Http;

namespace _.Dtos
{
    public class PhotoForDetailedDto
    {
        
        public IFormFile File { get; set; }
        public string Description { get; set; }
    }
}