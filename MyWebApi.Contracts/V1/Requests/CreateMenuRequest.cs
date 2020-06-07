using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebApi.Contracts.V1.Requests
{
    public class CreateMenuRequest
    {
        public string id { get; set; }
        public string Name { get; set; }
    }
}
