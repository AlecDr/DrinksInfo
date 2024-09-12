namespace Drinks_Info.Data.Repositories.Interfaces;

internal interface IImagesRepository
{
    public Task<string?> GetImageAsync(string imageUrl, int drinkId);

    public bool? DeleteImageFromLocalStorage(int drinkId);
}
