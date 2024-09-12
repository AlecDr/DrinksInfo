using Drinks_Info.Data.DTOs.Drinks;
using Drinks_Info.Data.Repositories.Implementations;
using Tests.Helpers;

namespace Drinks_Info.Tests.Unit;

public class DrinkRepositoryTests
{
    [Fact]
    public async Task FindDrink_MustReturnDrink()
    {
        // Arrange
        DrinkRepository drinkRepository = new DrinkRepository(StaticDrinksJsonHttpMessageHandler.WithExistingDrink());

        // Act
        DrinkCompleteDTO? drink = await drinkRepository.Find(1);

        // Assert
        Assert.NotNull(drink);
    }

    [Fact]
    public async Task FindDrink_MustNotReturnDrink()
    {
        // Arrange
        DrinkRepository drinkRepository = new DrinkRepository(StaticDrinksJsonHttpMessageHandler.WithNonExistingDrink());

        // Act
        DrinkCompleteDTO? drink = await drinkRepository.Find(1);

        // Assert
        Assert.Null(drink);
    }

    [Fact]
    public async Task FilterByCategory_MustReturnDrinks()
    {
        // Arrange
        DrinkRepository drinkRepository = new DrinkRepository(StaticDrinksJsonHttpMessageHandler.WithFilledDrinksList());

        // Act
        List<DrinkSimplifiedDTO> drinks = await drinkRepository.FilterByCategoryName("test drink category");

        // Assert
        Assert.NotEmpty(drinks);
    }

    [Fact]
    public async Task FilterByCategory_MustNotReturnDrinks()
    {
        // Arrange
        DrinkRepository drinkRepository = new DrinkRepository(StaticDrinksJsonHttpMessageHandler.WithEmptyDrinksList());

        // Act
        List<DrinkSimplifiedDTO> drinks = await drinkRepository.FilterByCategoryName("test drink category");

        // Assert
        Assert.Empty(drinks);
    }
}
