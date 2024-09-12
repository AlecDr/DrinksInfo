using Drinks_Info.Data.Repositories.Implementations;
using Tests.Helpers;

namespace Tests.Tests.Unit;

public class ImagesRepositoryTests
{
    [Fact]
    public async Task GetImage_MustReturnNullImagePath()
    {
        // Arrange
        ImagesRepository imagesRepository = new ImagesRepository(StaticDrinksJsonHttpMessageHandler.WithNonExistingImage());
        // delete old file
        imagesRepository.DeleteImageFromLocalStorage(1);

        // Act
        string? imagePath = await imagesRepository.GetImageAsync("https://0.0.0.0/some-random-image.jpg", 1);

        // Assert
        Assert.Null(imagePath);
    }

    [Fact]
    public async Task GetImage_MustReturnImagePath()
    {
        // Arrange
        ImagesRepository imagesRepository = new ImagesRepository(StaticDrinksJsonHttpMessageHandler.WithExistingImage());

        // Act
        string? imagePath = await imagesRepository.GetImageAsync("https://0.0.0.0/some-random-image.jpg", 1);
        // delete created file
        imagesRepository.DeleteImageFromLocalStorage(1);

        // Assert
        Assert.NotNull(imagePath);
    }
}
