using Drinks_Info.Data.DTOs.Drinks;

namespace Drinks_Info.Data.Repositories.Interfaces;

internal interface IDrinkRepository
{
    public Task<List<DrinkSimplifiedDTO>> FilterByCategoryName(string categoryName);

    public Task<DrinkCompleteDTO?> Find(int id);
}
