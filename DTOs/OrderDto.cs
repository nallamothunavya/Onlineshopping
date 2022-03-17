using System.Text.Json.Serialization;

namespace Onlinepsql.DTOs;

public record OrdersDTO
{
    [JsonPropertyName("order_id")]
    public long OrderId { get; set; }

    [JsonPropertyName("status")]
    public string OrderStatus { get; set; }

    [JsonPropertyName("products")]

    public List<ProductsDTO> Products {get;set;}

}

public record OrdersCreateDTO
{
    

    [JsonPropertyName("status")]
    public string OrderStatus { get; set; }



}

public record OrdersUpdateDTO
{


    [JsonPropertyName("status")]
    public string OrderStatus { get; set; }




}