using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebApi.Contracts.V1.Requests
{
    public class UpdateIngredientsRequest
    {
        

        public string Name { get; set; }

        public double Price { get; set; }

        public string Selectable { get; set; }
    }
}
