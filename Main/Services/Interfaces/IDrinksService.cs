using Drinks_Info.Data.DTOs.Categories;
using Drinks_Info.Data.DTOs.Drinks;

namespace Drinks_Info.Services.Interfaces;

internal interface IDrinksService
{
    public Task<List<CategoryDTO>> AllCategories();
    public Task<List<DrinkSimplifiedDTO>> AllDrinksByCategoryName(string categoryName);
    public Task<DrinkCompleteDTO?> FindDrinkById(int id);
    public Task<string?> GetImage(string imageUrl, int drinkId);
}
