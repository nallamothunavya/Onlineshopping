using System.Text.Json.Serialization;

namespace Onlinepsql.DTOs;

public record TagsDTO
{
    [JsonPropertyName("tag_id")]
    public long TagId { get; set; }

    [JsonPropertyName("tag_name")]
    
    public string TagName {get;set;}


}




