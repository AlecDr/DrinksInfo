using Drinks_Info.Data.DTOs.Drinks;

namespace Drinks_Info.Data.Repositories.Interfaces;

public interface IDrinkRepository
{
    Task<List<DrinkSimplifiedDTO>> FilterByCategoryName(string categoryName);

    Task<DrinkCompleteDTO?> Find(int id);
}
