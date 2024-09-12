
using Drinks_Info.Data.DTOs.Categories;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Tests.Helpers;

internal class StaticDrinksJsonHttpMessageHandler(string? json) : HttpMessageHandler
{
    private readonly string? Json = json;
    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage()
        {
            StatusCode = Json != null ? HttpStatusCode.OK : HttpStatusCode.NotFound,
            Content = Json != null ? new StringContent(Json, Encoding.UTF8, "application/json") : null,
        };

        return Task.FromResult(response);
    }
    public static HttpClient WithEmptyCategoryList()
    {
        string response = JsonSerializer.Serialize(new
        {
            Drinks = new IEnumerable<CategoryDTO>[] { }
        });
        StaticDrinksJsonHttpMessageHandler httpMessageHandler = new StaticDrinksJsonHttpMessageHandler(response);
        HttpClient client = new HttpClient(httpMessageHandler);

        return client;
    }
    public static HttpClient WithFilledCategoryList()
    {
        string response = JsonSerializer.Serialize(new
        {
            Drinks = new[] {
                new
                {
                    Name = "Category 1"
                },
                new
                {
                    Name = "Category 2"
                },
            }
        });
        StaticDrinksJsonHttpMessageHandler httpMessageHandler = new StaticDrinksJsonHttpMessageHandler(response);
        HttpClient client = new HttpClient(httpMessageHandler);

        return client;
    }
    public static HttpClient WithEmptyDrinksList()
    {
        string drinkResponseJson = JsonSerializer.Serialize(new
        {
            Drinks = new IEnumerable<string>[] { }
        });
        StaticDrinksJsonHttpMessageHandler httpMessageHandler = new StaticDrinksJsonHttpMessageHandler(drinkResponseJson);
        HttpClient httpClient = new HttpClient(httpMessageHandler);

        return httpClient;
    }
    public static HttpClient WithFilledDrinksList()
    {
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

        return httpClient;
    }
    public static HttpClient WithNonExistingDrink()
    {
        string drinkResponseJson = JsonSerializer.Serialize(new { });
        StaticDrinksJsonHttpMessageHandler httpMessageHandler = new StaticDrinksJsonHttpMessageHandler(drinkResponseJson);
        HttpClient httpClient = new HttpClient(httpMessageHandler);

        return httpClient;
    }
    public static HttpClient WithExistingDrink()
    {
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

        return httpClient;
    }
    public static HttpClient WithNonExistingImage()
    {
        StaticDrinksJsonHttpMessageHandler httpMessageHandler = new StaticDrinksJsonHttpMessageHandler(null);
        HttpClient httpClient = new HttpClient(httpMessageHandler);

        return httpClient;
    }
    public static HttpClient WithExistingImage()
    {
        StaticDrinksJsonHttpMessageHandler httpMessageHandler = new StaticDrinksJsonHttpMessageHandler("");
        HttpClient httpClient = new HttpClient(httpMessageHandler);

        return httpClient;
    }
}
