namespace Drinks_Info.Data.Repositories.Interfaces;

public interface IImagesRepository
{
    public Task<string?> GetImageAsync(string imageUrl, int drinkId);

    public bool? DeleteImageFromLocalStorage(int drinkId);
}
