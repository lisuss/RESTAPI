using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebApi.Contracts.V1.Queries
{
    public class GetAllPostsQuery
    {
        [FromQuery(Name ="userId")]
        public string UserId { get; set; }
    }
}
