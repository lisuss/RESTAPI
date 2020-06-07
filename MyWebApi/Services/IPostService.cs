using MyWebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync(GetAllPostsFilter filter = null, PaginationFilter paginationFilter = null);

        Task<Post> GetPostByIdAsync(Guid postid);

        Task<bool> UpdatePostAsync(Post postToUpdate);

        Task<bool> DeleteePostAsync(Guid postid);

        Task<bool> CreatePostAsync(Post post);

        Task<bool> UserOwnPostAsync(Guid postid, string getUserId);

        Task<List<Tag>> GetAllTagsAsync();

        Task<Tag> GetTagByNameAsync(string tagName);

               
        Task<bool> CreateTagAsync(Tag tag);

        
        Task<bool> DeleteTagAsync(string tagName);

    }
}
