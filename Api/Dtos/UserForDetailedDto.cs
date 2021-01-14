using System;
using System.Collections.Generic;
using _.Models;
using TempWeb.Models;

namespace _.Dtos
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        
        public string Gender { get; set; }
        
        public int Age { get; set; }
        
        public string KnownAs { get; set; }
        
        public DateTime Created { get; set; }
        
        public DateTime LastActive { get; set; }
        
        public string Introduce { get; set; }
        
        public string LookingFor { get; set; }
        
        public string Interests { get; set; }
        
        public string City { get; set; }
        
        public string Country { get; set; }
        
        public string PhotoUrl { get; set; }
        
        public ICollection<PhotoForDetailedDto> Photos { get; set; } 
        
    }
}