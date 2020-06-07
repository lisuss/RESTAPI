using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Contracts.V1;
using MyWebApi.Contracts.V1.Requests;
using MyWebApi.Contracts.V1.Responses;
using MyWebApi.Domain;
using MyWebApi.Extensions;
using MyWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApi.Controllers;
using AutoMapper;
using MyWebApi.Contracts.V1.Queries;
using Microsoft.OpenApi.Validations;
using Microsoft.EntityFrameworkCore.Internal;
using MyWebApi.Helpers;

namespace MyWebApi.Controllers.V1
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PostController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPostService _postService;
        private readonly IUriService _uriService;
        public PostController(IPostService postService, IMapper mapper, IUriService uriService)
        {
            _postService = postService;
            _mapper = mapper;
            _uriService = uriService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]

        public async Task<IActionResult> GetAll([FromQuery] GetAllPostsQuery query, [FromQuery]PaginationQuery paginationQuery)

        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var filter = _mapper.Map<GetAllPostsFilter>(query);
            var posts = await _postService.GetPostsAsync(filter, pagination);
            var postsResponse = _mapper.Map<List<PostResponse>>(posts);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<PostResponse>(postsResponse));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, postsResponse);
            return Ok(paginationResponse);
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid postid, [FromBody] UpdatePostRequest request)
        {
            var userOwnPost = await _postService.UserOwnPostAsync(postid, HttpContext.GetUserId());

            if (!userOwnPost)
            {
                return BadRequest(new { error = "You do not have right to do this" });
            }


            var post = await _postService.GetPostByIdAsync(postid);
            post.Name = request.Name;

            var updated = await _postService.UpdatePostAsync(post);

            if (updated)
                return Ok(new Response<PostResponse>(_mapper.Map<PostResponse>(post)));

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid postid)
        {
            var userOwnPost = await _postService.UserOwnPostAsync(postid, HttpContext.GetUserId());

            if (!userOwnPost)
            {
                return BadRequest(new { error = "You do not have right to do this" });
            }

            var deleted = await _postService.DeleteePostAsync(postid);
            if (deleted)
                return NoContent();

            return NotFound();
        }

        [HttpGet(ApiRoutes.Posts.Get)]
       
        public async Task<IActionResult> Get([FromRoute]Guid postid)
        {

            var post = await _postService.GetPostByIdAsync(postid);

            if (post == null)
                return NotFound();

            return Ok(new Response<PostResponse>(_mapper.Map<PostResponse>(post)));


        }


        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest postRequest)
        {
            var newPostId = Guid.NewGuid();
            var post = new Post
            {
                id = newPostId,
                Name = postRequest.Name,
                UserId = HttpContext.GetUserId(),
                Tags = postRequest.Tags.Select(x => new PostTag{PostId = newPostId, TagName = x}).ToList()
            };

          
            await _postService.CreatePostAsync(post);

            
            var locationUri = _uriService.GetPostUri(post.id.ToString());

            var response = new PostResponse {
                id = post.id,
                Name = post.Name,                
                Tags = post.Tags.Select(x => new TagResponse{ Name = x.TagName})
            };
            return Created(locationUri, new Response<PostResponse>(_mapper.Map<PostResponse>(post)));
        }
    }
}
