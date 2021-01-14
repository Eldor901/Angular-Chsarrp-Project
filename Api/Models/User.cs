using System;
using System.Collections.Generic;


namespace TempWeb.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public IList<Role> Roles { get; set; }
        
        public IList<Cuisine> Cuisines { get; set; }
        
        public IList<ProductCart> ProductCarts { get; set; }
    }
}