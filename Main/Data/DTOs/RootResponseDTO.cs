using System.Text.Json.Serialization;

namespace Drinks_Info.Data.DTOs;

public class RootResponseDTO<T>
{
    [JsonPropertyName("drinks")]
    public List<T>? Drinks { get; set; }
}
