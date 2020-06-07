using MyWebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public interface IMenuService
    {
        Task<List<Menu>> GetMenuAsync();

        Task<Menu> GetMenuByIdAsync(string menuid);

        Task<bool> UpdateMenuAsync(Menu menuToUpdate);

        Task<bool> DeleteMenuAsync(string menuid);

        Task<bool> CreateMenuAsync(Menu menu);

        Task<Menu> GetMenuByGroupAsync(string groupid);                 

       
    }
}
