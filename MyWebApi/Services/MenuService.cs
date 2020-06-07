using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public class MenuService : IMenuService
    {

        private readonly DataContext _dataContext;


        public MenuService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Menu> GetMenuByIdAsync(string menuid)
        {
            return await _dataContext.Menus.SingleOrDefaultAsync(x => x.id == menuid);
        }

        public async Task<List<Menu>> GetMenuAsync()
        {
            return await _dataContext.Menus.ToListAsync();
        }

        public async Task<bool> CreateMenuAsync(Menu menu)
        {
            menu.Tags?.ForEach(x => x.TagName = x.TagName.ToLower());

            
            await _dataContext.Menus.AddAsync(menu);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }
        public async Task<bool> UpdateMenuAsync(Menu menuToUpdate)
        {

            
            _dataContext.Menus.Update(menuToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteMenuAsync(string menuId)
        {
            var menu = await GetMenuByIdAsync(menuId);

            if (menu == null)
                return false;

            _dataContext.Menus.Remove(menu);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
        public async Task<Menu> GetMenuByGroupAsync(string groupId)
        {
            return await _dataContext.Menus.SingleOrDefaultAsync(x => x.id == groupId);
        }

        
    }
}
