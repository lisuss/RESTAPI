using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebApi.Contracts.V1.Requests
{
    public class UpdateMenuRequest
    {
        
        public string id { get; set; }
        public string Name { get; set; }

        

        public string MaterialGroup { get; set; }

        public DateTime CreationDate { get; set; }

        public string Discounted { get; set; }
        
        public double Price { get; set; }

        public string Description { get; set; }

        public string changeable { get; set; }

    }
}
