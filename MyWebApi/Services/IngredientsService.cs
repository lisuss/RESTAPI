using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Services
{
    public class IngredientsService : IIngredientsService
    {
        private readonly DataContext _dataContext;

        public IngredientsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Ingredients> GetIngredientsByIdAsync(string id)
        {
            return await _dataContext.Ingredients.SingleOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<Ingredients>> GetIngredientsAsync()
        {
            return await _dataContext.Ingredients.ToListAsync();
        }

        public async Task<bool> CreateIngredientsAsync(Ingredients ingredients)
        {



            await _dataContext.Ingredients.AddAsync(ingredients);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdateIngredientsAsync(Ingredients ingredientToUpdate)
        {


            _dataContext.Ingredients.Update(ingredientToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteIngredientsAsync(string ingredientsId)
        {
            var ingredients = await GetIngredientsByIdAsync(ingredientsId);

            if (ingredients == null)
                return false;

            _dataContext.Ingredients.Remove(ingredients);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
