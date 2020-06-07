using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Contracts.V1;
using MyWebApi.Contracts.V1.Requests;
using MyWebApi.Contracts.V1.Responses;
using MyWebApi.Domain;
using MyWebApi.Extensions;
using MyWebApi.Services;
namespace MyWebApi.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    public class TagsController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;


        public TagsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }
        /// <summary>
        ///  Returns all the tags in the system
        /// </summary>
        /// <response code="200">Returns all the tags in the system</response>

        [HttpGet(ApiRoutes.Tags.GetAll)]
       
        public async Task<IActionResult> GetAll()
        {
            var tags = await _postService.GetAllTagsAsync();
            var tagResponses = tags.Select(tag => new TagResponse { Name = tag.Name });
            return Ok(tagResponses);
        }
        [HttpGet(ApiRoutes.Tags.Get)]
        public async Task<IActionResult> Get([FromRoute]string tagName)
        {
            var tag = await _postService.GetTagByNameAsync(tagName);
            if (tag == null)
            {
                return NotFound();
            }

            return Ok(new TagResponse { Name = tag.Name });
        }
        /// <summary>
        ///  Creates tag in the system
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <response code="201">Creates tag in system</response>
        ///  <response code="400">Unable to create the tag due to validation error</response>
        [HttpPost(ApiRoutes.Tags.Create)]
        [ProducesResponseType(typeof(TagResponse), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Create([FromBody] CreateTagRequest request)
        {
            
            
           
            var newTag = new Tag
            {
                Name = request.TagName,
                CreatorId = HttpContext.GetUserId(),
                CreatedOn = DateTime.UtcNow
            };

            var created = await _postService.CreateTagAsync(newTag);
            if (!created)
            {
                return BadRequest(new  ErrorResponse{ Errors = new List<ErrorModel>{new ErrorModel { Message = "unable to create a tag" }  } });
            }
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Tags.Get.Replace("TagName", newTag.Name);
            return Created(locationUri, new TagResponse { Name = newTag.Name });
        }
            [HttpDelete(ApiRoutes.Tags.Delete)]
           
        public async Task<IActionResult> Delete([FromRoute] string tagName)
        {
            var deleted = await _postService.DeleteTagAsync(tagName);

            if (deleted)
                return NoContent();

            return NotFound();
        }
        
    }
}
