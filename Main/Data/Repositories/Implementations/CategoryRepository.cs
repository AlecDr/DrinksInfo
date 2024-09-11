using Drinks_Info.Data.DTOs;
using Drinks_Info.Data.DTOs.Categories;
using Drinks_Info.Data.Repositories.Interfaces;
using System.Net.Http.Json;

namespace Drinks_Info.Data.Repositories.Implementations;

internal class CategoryRepository : ICategoryRepository
{
    private readonly HttpClient _httpClient;

    public CategoryRepository(
        HttpClient httpClient
    )
    {
        _httpClient = httpClient;
    }


    public async Task<List<CategoryDTO>> All()
    {
        RootResponseDTO<CategoryDTO>? response = await _httpClient.GetFromJsonAsync<RootResponseDTO<CategoryDTO>>("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");

        if (response != null)
        {
            return response.Drinks;
        }

        return [];
    }
}
