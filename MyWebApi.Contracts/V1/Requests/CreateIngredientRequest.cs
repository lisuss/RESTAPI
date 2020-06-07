using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebApi.Contracts.V1.Requests
{
    public class CreateIngredientRequest
    {
        public string id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Selectable { get; set; }
    }
}
