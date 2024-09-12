using Drinks_Info.Data.DTOs.Drinks;
using Drinks_Info.Data.Repositories.Implementations;
using System.Text.Json;
using Tests.Helpers;

namespace Drinks_Info.Tests.Unit;

public class DrinkRepositoryTests
{
    [Fact]
    public async Task FindDrink_MustReturnDrink()
    {
        // Arrange
        string drinkResponseJson = JsonSerializer.Serialize(new
        {
            drinks = new[]
                {
                    new
                        {
                            Id = "1",
                            Name = "test drink",
                            DrinkAlternative = "test drink alternative",
                            Tags = "test drink tag",
                            Category = "test drink category",
                            Glass = "test drink glass",
                            Instructions = "test drink instructions",
                            Thumb = "test drink thumb",
                            Ingredient1 = "test drink ingredient 1",
                            Ingredient2 = "test drink ingredient 2",
                            Ingredient3 = "test drink ingredient 3",
                            Ingredient4 = "test drink ingredient 4",
                            Ingredient5 = "test drink ingredient 5",
                            Ingredient6 = "test drink ingredient 6",
                            Ingredient7 = "test drink ingredient 7",
                            Ingredient8 = "test drink ingredient 8",
                            Ingredient9 = "test drink ingredient 9",
                            Ingredient10 = "test drink ingredient 10",
                            Ingredient11 = "test drink ingredient 11",
                            Ingredient12 = "test drink ingredient 12",
                            Ingredient13 = "test drink ingredient 13",
                            Ingredient14 = "test drink ingredient 14",
                            Ingredient15 = "test drink ingredient 15",
                            DateModified = "test drink date",
                        }
                }
        });
        StaticDrinksJsonHttpMessageHandler httpMessageHandler = new StaticDrinksJsonHttpMessageHandler(drinkResponseJson);
        HttpClient httpClient = new HttpClient(httpMessageHandler);
        DrinkRepository drinkRepository = new DrinkRepository(httpClient);

        // Act
        DrinkCompleteDTO? drink = await drinkRepository.Find(1);

        // Assert
        Assert.NotNull(drink);
    }

    [Fact]
    public async Task FindDrink_MustNotReturnDrink()
    {
        // Arrange
        string drinkResponseJson = JsonSerializer.Serialize(new { });
        StaticDrinksJsonHttpMessageHandler httpMessageHandler = new StaticDrinksJsonHttpMessageHandler(drinkResponseJson);
        HttpClient httpClient = new HttpClient(httpMessageHandler);
        DrinkRepository drinkRepository = new DrinkRepository(httpClient);

        // Act
        DrinkCompleteDTO? drink = await drinkRepository.Find(1);

        // Assert
        Assert.Null(drink);
    }

    [Fact]
    public async Task FilterByCategory_MustReturnDrinks()
    {
        // Arrange
        string drinkResponseJson = JsonSerializer.Serialize(new
        {
            Drinks = new[]
                {
                    new
                        {
                            Id = "1",
                            Name = "test drink",
                            DrinkAlternative = "test drink alternative",
                            Tags = "test drink tag",
                            Category = "test drink category",
                            Glass = "test drink glass",
                            Instructions = "test drink instructions",
                            Thumb = "test drink thumb",
                            Ingredient1 = "test drink ingredient 1",
                            Ingredient2 = "test drink ingredient 2",
                            Ingredient3 = "test drink ingredient 3",
                            Ingredient4 = "test drink ingredient 4",
                            Ingredient5 = "test drink ingredient 5",
                            Ingredient6 = "test drink ingredient 6",
                            Ingredient7 = "test drink ingredient 7",
                            Ingredient8 = "test drink ingredient 8",
                            Ingredient9 = "test drink ingredient 9",
                            Ingredient10 = "test drink ingredient 10",
                            Ingredient11 = "test drink ingredient 11",
                            Ingredient12 = "test drink ingredient 12",
                            Ingredient13 = "test drink ingredient 13",
                            Ingredient14 = "test drink ingredient 14",
                            Ingredient15 = "test drink ingredient 15",
                            DateModified = "test drink date",
                        }
                }
        });
        StaticDrinksJsonHttpMessageHandler httpMessageHandler = new StaticDrinksJsonHttpMessageHandler(drinkResponseJson);
        HttpClient httpClient = new HttpClient(httpMessageHandler);
        DrinkRepository drinkRepository = new DrinkRepository(httpClient);

        // Act
        List<DrinkSimplifiedDTO> drinks = await drinkRepository.FilterByCategoryName("test drink category");

        // Assert
        Assert.NotEmpty(drinks);
    }

    [Fact]
    public async Task FilterByCategory_MustNotReturnDrinks()
    {
        // Arrange
        string drinkResponseJson = JsonSerializer.Serialize(new
        {
            Drinks = new IEnumerable<string>[] { }
        });
        StaticDrinksJsonHttpMessageHandler httpMessageHandler = new StaticDrinksJsonHttpMessageHandler(drinkResponseJson);
        HttpClient httpClient = new HttpClient(httpMessageHandler);
        DrinkRepository drinkRepository = new DrinkRepository(httpClient);

        // Act
        List<DrinkSimplifiedDTO> drinks = await drinkRepository.FilterByCategoryName("test drink category");

        // Assert
        Assert.Empty(drinks);
    }
}
