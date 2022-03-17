
using Onlinepsql.DTOs;

namespace Onlinepsql.Models;


public record Orders
{
    
    public long OrderId { get; set; }
    public string OrderStatus { get; set; }

    
    
    

    public OrdersDTO asDto => new OrdersDTO
    {
        OrderId = OrderId,
        OrderStatus = OrderStatus,
        
    };
}
