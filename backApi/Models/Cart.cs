﻿using _.Models;

 namespace TempWeb.Models
{
    public class Cart
    {
        public int Id { get; set; }
        
        public string comment { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}