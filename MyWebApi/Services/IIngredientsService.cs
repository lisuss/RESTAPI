using MyWebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public interface IIngredientsService 
    {
        Task<List<Ingredients>> GetIngredientsAsync();

        Task<Ingredients> GetIngredientsByIdAsync(string id);

        Task<bool> UpdateIngredientsAsync(Ingredients ingredientToUpdate);

        Task<bool> DeleteIngredientsAsync(string id);

        Task<bool> CreateIngredientsAsync(Ingredients ingredients);
    }
}
