using Drinks_Info.Data.DTOs.Categories;
using Drinks_Info.Data.Repositories.Implementations;
using System.Text.Json;
using Tests.Helpers;

namespace Tests.Tests.Unit;

public class CategoryRepositoryTests
{
    [Fact]
    public async Task AllCategories_MustReturnEmptyList()
    {
        // Arrange
        string response = JsonSerializer.Serialize(new
        {
            Drinks = new IEnumerable<CategoryDTO>[] { }
        });
        StaticDrinksJsonHttpMessageHandler httpMessageHandler = new StaticDrinksJsonHttpMessageHandler(response);
        HttpClient client = new HttpClient(httpMessageHandler);
        CategoryRepository categoryRepository = new CategoryRepository(client);

        // Act
        List<CategoryDTO> categories = await categoryRepository.All();

        // Assert
        Assert.Empty(categories);
    }

    [Fact]
    public async Task AllCategories_MustReturnNotEmptyList()
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
        CategoryRepository categoryRepository = new CategoryRepository(client);

        // Act
        List<CategoryDTO> categories = await categoryRepository.All();

        // Assert
        Assert.NotEmpty(categories);
    }

}
