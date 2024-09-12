using Drinks_Info.Data.Repositories.Interfaces;

namespace Drinks_Info.Data.Repositories.Implementations;

public class ImagesRepository : IImagesRepository
{
    private readonly HttpClient _httpClient;

    public ImagesRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string?> GetImageAsync(string imageUrl, int drinkId)
    {
        string savePath = Path.Combine(Directory.GetCurrentDirectory(), $"{drinkId}.jpg");

        if (File.Exists(savePath))
        {
            return savePath;
        }

        HttpResponseMessage response = await _httpClient.GetAsync(imageUrl);

        if (response != null)
        {
            if (response.IsSuccessStatusCode)
            {
                byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();

                await File.WriteAllBytesAsync(savePath, imageBytes);

                return savePath;
            }
        }

        return null;
    }

    public bool? DeleteImageFromLocalStorage(int drinkId)
    {
        string savePath = Path.Combine(Directory.GetCurrentDirectory(), $"{drinkId}.jpg");

        if (File.Exists(savePath))
        {
            File.Delete(savePath);

            return true;
        }

        return false;
    }
}
