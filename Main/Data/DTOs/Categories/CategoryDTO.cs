using System.Text.Json.Serialization;

namespace Drinks_Info.Data.DTOs.Categories;

public class CategoryDTO
{
    [JsonPropertyName("strCategory")]
    public string Name { get; set; }

    public CategoryDTO(string name)
    {
        Name = name;
    }
}
