using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Domain
{
    public class Menu
    {
        [Key]
        public string id { get; set; }

        public string MealId { get; set; }

        public string MaterialGroup { get; set; }

        public DateTime CreationDate { get; set; }

        public string Discounted { get; set; }

        public string Name { get; set; }
        
        public double Price { get; set; }

        public string Description { get; set; }

        public string changeable { get; set; }


        public virtual List<PostTag> Tags { get; set; }
    }
}
