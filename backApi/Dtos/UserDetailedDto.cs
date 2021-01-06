using System.Collections.Generic;
using TempWeb.Models;

namespace _.Dtos
{
    public class UserDetailedDto
    {
        public int Id { get; set; }
        
        public string Username { get; set; }
        
        public IList<Cuisine> Cuisines { get; set; }
        
        public IList<Cart> ProductCarts { get; set; }
        
        public RolesDto Role { get; set; }
    }
}