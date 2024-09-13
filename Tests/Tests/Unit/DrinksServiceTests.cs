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
        DrinkRepository drinkRepository = new DrinkRepository(StaticDrinksJsonHttpMessageHandler.WithFilledDrinksList());
        ImagesRepository imagesRepository = new ImagesRepository(StaticDrinksJsonHttpMessageHandler.WithNonExistingImage());
        DrinksService drinksService = new DrinksService(drinkRepository, categoryRepository, imagesRepository);

        // Act
        List<DrinkSimplifiedDTO> drinks = await drinksService.AllDrinksByCategoryName("test drink category");

        // Assert
        Assert.NotEmpty(drinks);
    }

    [Fact]
    public async Task AllDrinksByCategoryName_MustNotReturnDrinksByCategory()
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

    [Fact]
    public async Task FindDrinkById_MustReturnDrink()
    {
        // Arrange
        CategoryRepository categoryRepository = new CategoryRepository(StaticDrinksJsonHttpMessageHandler.WithFilledCategoryList());
        DrinkRepository drinkRepository = new DrinkRepository(StaticDrinksJsonHttpMessageHandler.WithExistingDrink());
        ImagesRepository imagesRepository = new ImagesRepository(StaticDrinksJsonHttpMessageHandler.WithNonExistingImage());
        DrinksService drinksService = new DrinksService(drinkRepository, categoryRepository, imagesRepository);

        // Act
        DrinkCompleteDTO? drink = await drinksService.FindDrinkById(1);

        // Assert
        Assert.NotNull(drink);
    }

    [Fact]
    public async Task FindDrinkById_MustNotReturnDrink()
    {
        // Arrange
        CategoryRepository categoryRepository = new CategoryRepository(StaticDrinksJsonHttpMessageHandler.WithFilledCategoryList());
        DrinkRepository drinkRepository = new DrinkRepository(StaticDrinksJsonHttpMessageHandler.WithNonExistingDrink());
        ImagesRepository imagesRepository = new ImagesRepository(StaticDrinksJsonHttpMessageHandler.WithNonExistingImage());
        DrinksService drinksService = new DrinksService(drinkRepository, categoryRepository, imagesRepository);

        // Act
        DrinkCompleteDTO? drink = await drinksService.FindDrinkById(1);

        // Assert
        Assert.Null(drink);
    }

    //public async Task GetImage_MustReturnImagePath() { }
    //public async Task GetImage_MustNotReturnImagePath() { }
}
