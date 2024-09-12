using Drinks_Info.Data.DTOs.Categories;
using Drinks_Info.Data.Repositories.Implementations;
using Tests.Helpers;

namespace Tests.Tests.Unit;

public class CategoryRepositoryTests
{
    [Fact]
    public async Task AllCategories_MustReturnEmptyList()
    {
        // Arrange
        CategoryRepository categoryRepository = new CategoryRepository(StaticDrinksJsonHttpMessageHandler.WithEmptyCategoryList());

        // Act
        List<CategoryDTO> categories = await categoryRepository.All();

        // Assert
        Assert.Empty(categories);
    }

    [Fact]
    public async Task AllCategories_MustReturnNotEmptyList()
    {
        // Arrange
        CategoryRepository categoryRepository = new CategoryRepository(StaticDrinksJsonHttpMessageHandler.WithFilledCategoryList());

        // Act
        List<CategoryDTO> categories = await categoryRepository.All();

        // Assert
        Assert.NotEmpty(categories);
    }
}
