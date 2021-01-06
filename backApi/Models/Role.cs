﻿using System.Collections;
 using System.Collections.Generic;

 namespace TempWeb.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string name { get; set; }
        
        public IList<User> Users { get; set; }
    }
}