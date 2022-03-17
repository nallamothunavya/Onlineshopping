using Dapper;
using Onlinepsql.Models;
using Onlinepsql.Utilities;

namespace Onlinepsql.Repositories;

public interface IOrdersRepository
{
    Task Update(Orders Item);
    Task Delete(long OrderId);
    Task<List<Orders>> GetList();
    Task<Orders> GetById(long OrderId);

    Task<List<Orders>> GetListByCustomerId(long CustomerId);

    Task<List<Orders>> GetListByProductId(long ProductId);
}

public class OrdersRepository : BaseRepository, IOrdersRepository
{
    public OrdersRepository(IConfiguration config) : base(config)
    {

    }


    
    public async Task Delete(long OrderId)
    {
        var query = $@"DELETE FROM {TableNames.orders} WHERE order_id = @OrderId";

        using (var con = NewConnection)
            await con.ExecuteAsync(query, new { OrderId });
    }

    

    public async Task<List<Orders>> GetList()
    {
        var query = $@"SELECT * FROM {TableNames.orders}";

        using (var con = NewConnection)
            return (await con.QueryAsync<Orders>(query)).AsList();
    }

   
    public async Task<Orders> GetById(long OrderId)
    {
        var query = $@"SELECT * FROM {TableNames.orders} 
        WHERE order_id = @OrderId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Orders>(query, new { OrderId });
    }

    public async Task Update(Orders Item)
    {
        var query = $@"UPDATE {TableNames.orders} SET order_status = @OrderStatus"; 
       

        using (var con = NewConnection)
            await con.ExecuteAsync(query, Item);
    }

    public async Task<List<Orders>> GetListByCustomerId(long CustomerId)
    {
        var query = $@"SELECT * FROM {TableNames.orders}  WHERE customer_id = @CustomerId";

        

        using (var con = NewConnection)
            return (await con.QueryAsync<Orders>(query, new { CustomerId })).AsList();
    }

    public async Task<List<Orders>> GetListByProductId(long ProductId)
    {
         var query =$@"SELECT *FROM {TableNames.order_product} op
        LEFT JOIN {TableNames.orders} o ON o.order_id = op.order_id
        WHERE op.product_id = @ProductId";

        using (var con = NewConnection)

        return(await con.QueryAsync<Orders>(query,new {ProductId})).AsList();

    }
}