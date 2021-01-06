using System.Collections;
using System.Collections.Generic;

namespace _.Models
{
    public class Ingridient
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string? img_url { get; set; }
        
        public int?  IngridientCategoryId { get; set; }
        public IngridientCategory IngridientCategory{ get; set; }
        public int? ProductId { get; set; }
        public Product Product{ get; set; }
    }
}