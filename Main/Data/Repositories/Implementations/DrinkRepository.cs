using Drinks_Info.Data.DTOs;
using Drinks_Info.Data.DTOs.Drinks;
using Drinks_Info.Data.Repositories.Interfaces;
using System.Net.Http.Json;

namespace Drinks_Info.Data.Repositories.Implementations;

internal class DrinkRepository : IDrinkRepository
{
    private readonly HttpClient _httpClient;

    public DrinkRepository(
        HttpClient httpClient
    )
    {
        _httpClient = httpClient;
    }

    public async Task<List<DrinkSimplifiedDTO>> FilterByCategoryName(string categoryName)
    {
        string option = categoryName;
        RootResponseDTO<DrinkSimplifiedDTO>? response = await _httpClient.GetFromJsonAsync<RootResponseDTO<DrinkSimplifiedDTO>>($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={categoryName}");
        if (response != null)
        {
            return response.Drinks;
        }

        return [];
    }

    public async Task<DrinkCompleteDTO?> Find(int id)
    {
        RootResponseDTO<DrinkCompleteDTO>? response = await _httpClient.GetFromJsonAsync<RootResponseDTO<DrinkCompleteDTO>>($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}");

        if (response != null)
        {
            if (response.Drinks.Count > 0)
            {
                return response.Drinks[0];
            }
        }

        return null;
    }
}
