
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Contracts.V1.Responses
{
    public class PostResponse
    {
        public Guid id { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }
            
             
      public  IEnumerable<TagResponse> Tags { get; set; }
    }
}
