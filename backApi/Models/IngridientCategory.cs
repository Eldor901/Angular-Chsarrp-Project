using System.Collections.Generic;

namespace _.Models
{
    public class IngridientCategory
    {
        public int Id { get; set; }
        public string name { get; set;}
        
        public IList<Ingridient>  Ingridients { get; set; }
        
        

    }
}