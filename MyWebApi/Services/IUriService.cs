using MyWebApi.Contracts.V1.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public interface IUriService
    {
        Uri GetPostUri(string postId);

        Uri GetAllPostsUri(PaginationQuery pagination = null);
    } 
}
