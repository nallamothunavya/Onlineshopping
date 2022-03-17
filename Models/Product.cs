using Onlinepsql.DTOs;

namespace Onlinepsql.Models;



public record Products
{
    public long ProductId { get; set; }
    public string ProductName { get; set; }

    public decimal Price { get; set; }
    public string Description { get; set; }
    public string InStock { get; set; }
   
    public long OrderId {get;set;}    

    
    

    public ProductsDTO asDto => new ProductsDTO
    {
        ProductId = ProductId,
        ProductName = ProductName,
        Price = Price,
        InStock = InStock,
        Description = Description,
    };
}
