using System.Text.Json.Serialization;

namespace Drinks_Info.Data.DTOs.Drinks;

internal class DrinkSimplifiedDTO
{
    [JsonPropertyName("strDrink")]
    public string Name { get; set; }

    [JsonPropertyName("strDrinkThumb")]
    public string Thumb { get; set; }

    [JsonPropertyName("idDrink")]
    public string Id { get; set; }

    public DrinkSimplifiedDTO(string name, string thumb, string id)
    {
        Name = name;
        Thumb = thumb;
        Id = id;
    }
}
