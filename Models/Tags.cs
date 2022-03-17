using Onlinepsql.DTOs;

namespace Onlinepsql.Models;



public record Tags
{
    public long TagId { get; set; }
    public string TagName { get; set; }

    public long OrderId { get; set; }

    public long ProductId { get; set; }
    

    public TagsDTO asDto => new TagsDTO
    {
        TagId = TagId,
        TagName = TagName,
        
        
        
    };
}