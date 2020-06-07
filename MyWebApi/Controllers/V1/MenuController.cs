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
    public class MenuController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }
        [HttpGet(ApiRoutes.Menus.GetAll)]

        public async Task<IActionResult> GetAll()
        {
            var menus = await _menuService.GetMenuAsync();
            var menusResponses = _mapper.Map<List<MenuResponse>>(menus);
            return Ok(menusResponses);
        }

        [HttpDelete(ApiRoutes.Menus.Delete)]
        public async Task<IActionResult> Delete([FromRoute]string MealId)
        {

            var deleted = await _menuService.DeleteMenuAsync(MealId);
            if (deleted)
                return NoContent();

            return NotFound();
        }

        [HttpPut(ApiRoutes.Menus.Update)]
        public async Task<IActionResult> Update([FromRoute]string MealId, [FromBody] UpdateMenuRequest request)
        {
          

            var menu = await _menuService.GetMenuByIdAsync(MealId);
            menu.id = request.id;
            
           
          /*  menu.MealId = request.MealId;
            menu.Name = request.Name;
            menu.MaterialGroup = request.MaterialGroup;
            menu.CreationDate = request.CreationDate;
            menu.Discounted = request.Discounted;
            menu.Price = request.Price;
            menu.Description = request.Description;
            menu.changeable = request.changeable; */

            var updated = await _menuService.UpdateMenuAsync(menu);

            if (updated)
                return Ok(new Response<MenuResponse>(_mapper.Map<MenuResponse>(menu)));

            return NotFound();
        }

        [HttpGet(ApiRoutes.Menus.Get)]

        public async Task<IActionResult> Get([FromRoute]string MealId)
        {

            var menu = await _menuService.GetMenuByIdAsync(MealId);

            if (menu == null)
                return NotFound();

            return Ok(new Response<MenuResponse>(_mapper.Map<MenuResponse>(menu)));


        }
        [HttpPost(ApiRoutes.Menus.Create)]
        public async Task<IActionResult> Create([FromBody] CreateMenuRequest menuRequest)
        {
            
            var menu = new Menu
            {
               id = menuRequest.id,
               Name = menuRequest.Name,

            };


            await _menuService.CreateMenuAsync(menu);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Menus.Get.Replace("{id}", menu.id.ToString());


            return Created(locationUri, new MenuResponse { id = menu.id });
        }
    }
}
