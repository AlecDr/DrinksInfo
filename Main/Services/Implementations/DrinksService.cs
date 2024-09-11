using Drinks_Info.Data.DTOs.Categories;
using Drinks_Info.Data.DTOs.Drinks;
using Drinks_Info.Data.Repositories.Interfaces;
using Drinks_Info.Services.Interfaces;

namespace Drinks_Info.Services.Implementations;

internal class DrinksService : IDrinksService
{
    private readonly IDrinkRepository _drinkRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IImagesRepository _imagesRepository;

    public DrinksService(
        IDrinkRepository drinkRepository,
        ICategoryRepository categoryRepository,
        IImagesRepository imagesRepository)
    {
        _drinkRepository = drinkRepository;
        _categoryRepository = categoryRepository;
        _imagesRepository = imagesRepository;
    }

    public Task<List<CategoryDTO>> AllCategories()
    {
        return _categoryRepository.All();
    }

    public Task<List<DrinkSimplifiedDTO>> AllDrinksByCategoryName(string categoryName)
    {
        return _drinkRepository.FilterByCategoryName(categoryName);
    }

    public Task<DrinkCompleteDTO?> FindDrinkById(int id)
    {
        return _drinkRepository.Find(id);
    }

    public Task<string?> GetImage(string imageUrl, int drinkId)
    {
        return _imagesRepository.GetImageAsync(imageUrl, drinkId);
    }
}
