using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Contracts.V1;
using MyWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApi.Contracts.V1.Requests;
using MyWebApi.Contracts.V1.Responses;
using MyWebApi.Domain;

namespace MyWebApi.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class IngredientController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IIngredientsService _ingredientsService;


        public IngredientController(IIngredientsService ingredientsService, IMapper mapper)
        {
            _ingredientsService = ingredientsService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Ingredients.GetAll)]

        public async Task<IActionResult> GetAll()
        {
            var ingredients = await _ingredientsService.GetIngredientsAsync();
            var ingredientsResponse = _mapper.Map<List<IngredientsResponse>>(ingredients);
            return Ok(ingredientsResponse);
        }
        [HttpDelete(ApiRoutes.Ingredients.Delete)]
        public async Task<IActionResult> Delete([FromRoute]string id)
        {

            var deleted = await _ingredientsService.DeleteIngredientsAsync(id);
            if (deleted)
                return NoContent();

            return NotFound();
        }
        [HttpPut(ApiRoutes.Ingredients.Update)]
        public async Task<IActionResult> Update([FromRoute]string id, [FromBody] UpdateIngredientsRequest request)
        {


            var ingredient = await _ingredientsService.GetIngredientsByIdAsync(id);
            
            ingredient.Name = request.Name;
            ingredient.Price = request.Price;
            ingredient.Selectable = request.Selectable;
          

            var updated = await _ingredientsService.UpdateIngredientsAsync(ingredient);
            

            if (updated)
                return Ok(new Response<IngredientsResponse>(_mapper.Map<IngredientsResponse>(ingredient)));

            return NotFound();
        }

        [HttpGet(ApiRoutes.Ingredients.Get)]

        public async Task<IActionResult> Get([FromRoute]string id)
        {

            var ingredient = await _ingredientsService.GetIngredientsByIdAsync(id);

            if (ingredient == null)
                return NotFound();

            return Ok(new Response<IngredientsResponse>(_mapper.Map<IngredientsResponse>(ingredient)));

        }

        [HttpPost(ApiRoutes.Ingredients.Create)]
        public async Task<IActionResult> Create([FromBody] CreateIngredientRequest ingredientsRequest)
        {

            var ingredient = new Ingredients
            {
                id = ingredientsRequest.id,
                Name = ingredientsRequest.Name,
                Price = ingredientsRequest.Price,
                Selectable = ingredientsRequest.Selectable

            };


            await _ingredientsService.CreateIngredientsAsync(ingredient);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Ingredients.Get.Replace("{id}", ingredient.id.ToString());


            return Created(locationUri, new IngredientsResponse { id = ingredient.id });
        }
    }
}
