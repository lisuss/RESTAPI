using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Domain
{
    public class Ingredients
    {
        [Key]
        public string id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Selectable { get; set; }

        


    }
}
