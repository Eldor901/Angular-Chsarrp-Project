﻿using System.Collections.Generic;
 using _.Models;

 namespace TempWeb.Models
{
    public class Cuisine
    {
        public int Id { get; set; }
        public string name { get; set;}
        public string imgurl { get; set; }
        public string desc { get; set; }
        
        public IList<Product> Products { get; set; }
        
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}