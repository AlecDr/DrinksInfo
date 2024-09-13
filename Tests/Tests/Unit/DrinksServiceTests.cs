using Drinks_Info.Data.DTOs.Categories;
using Drinks_Info.Data.DTOs.Drinks;
using Drinks_Info.Data.Repositories.Implementations;
using Drinks_Info.Services.Implementations;
using Tests.Helpers;

namespace Tests.Tests.Unit;

public class DrinksServiceTests
{
    [Fact]
    public async Task AllCategories_MustReturnEmptyList()
    {
        // Arrange
        CategoryRepository categoryRepository = new CategoryRepository(StaticDrinksJsonHttpMessageHandler.WithEmptyCategoryList());
        DrinkRepository drinkRepository = new DrinkRepository(StaticDrinksJsonHttpMessageHandler.WithExistingDrink());
        ImagesRepository imagesRepository = new ImagesRepository(StaticDrinksJsonHttpMessageHandler.WithNonExistingImage());
        DrinksService drinksService = new DrinksService(drinkRepository, categoryRepository, imagesRepository);

        // Act
        List<CategoryDTO> categories = await drinksService.AllCategories();

        // Assert
        Assert.Empty(categories);
    }

    [Fact]
    public async Task AllCategories_MustReturnNotEmptyList()
    {
        // Arrange
        CategoryRepository categoryRepository = new CategoryRepository(StaticDrinksJsonHttpMessageHandler.WithFilledCategoryList());
        DrinkRepository drinkRepository = new DrinkRepository(StaticDrinksJsonHttpMessageHandler.WithExistingDrink());
        ImagesRepository imagesRepository = new ImagesRepository(StaticDrinksJsonHttpMessageHandler.WithNonExistingImage());
        DrinksService drinksService = new DrinksService(drinkRepository, categoryRepository, imagesRepository);

        // Act
        List<CategoryDTO> categories = await drinksService.AllCategories();

        // Assert
        Assert.NotEmpty(categories);
    }

    [Fact]
    public async Task AllDrinksByCategoryName_MustReturnDrinksByCategory()
    {
        // Arrange
        CategoryRepository categoryRepository = new CategoryRepository(StaticDrinksJsonHttpMessageHandler.WithFilledCategoryList());
        DrinkRepository drinkRepository = new DrinkRepository(StaticDrinksJsonHttpMessageHandler.WithEmptyDrinksList());
        ImagesRepository imagesRepository = new ImagesRepository(StaticDrinksJsonHttpMessageHandler.WithNonExistingImage());
        DrinksService drinksService = new DrinksService(drinkRepository, categoryRepository, imagesRepository);

        // Act
        List<DrinkSimplifiedDTO> drinks = await drinksService.AllDrinksByCategoryName("test drink category");

        // Assert
        Assert.Empty(drinks);
    }

    //public async Task AllDrinksByCategoryName_MustNotReturnDrinksByCategory() { }

    //public async Task FindDrinkById_MustReturnDrink() { }
    //public async Task FindDrinkById_MustNotReturnDrink() { }

    //public async Task GetImage_MustReturnImagePath() { }
    //public async Task GetImage_MustNotReturnImagePath() { }


}
