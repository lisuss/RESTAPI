using System;
using System.Collections.Generic;

namespace MyWebApi.Contracts.V1.Responses
{
    public class MenuResponse
    {
        public string id { get; set; }

        public string MealId { get; set; }

        public string MaterialGroup { get; set; }

        public DateTime CreationDate { get; set; }

        public string Discounted { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string changeable { get; set; }

        public double price { get; set; }
    }
}
