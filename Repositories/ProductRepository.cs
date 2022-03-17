using Dapper;
using Onlinepsql.Models;
using Onlinepsql.Utilities;

namespace Onlinepsql.Repositories;

public interface IProductsRepository
{
    Task<Products> Create(Products Item);
   
    Task<bool> Delete(long ProductId);
    Task<List<Products>> GetList();
    Task<Products> GetById(long ProductId);

    Task<List<Products>> GetListByOrderId(long OrderId);
}

public class ProductsRepository : BaseRepository, IProductsRepository
{
    public ProductsRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Products> Create(Products Item)
    {
        var query = $@"INSERT INTO {TableNames.products} (product_id, product_name, price,
        discription, in_stock) VALUES (@ProductId, @ProductName, @Price, @Discription, @InStock) 
        RETURNING *";

        using (var con = NewConnection)
            return await con.QuerySingleAsync<Products>(query, Item);
    }

    
    public async Task<bool> Delete(long ProductId)
    {
        var query = $@"DELETE FROM {TableNames.products} WHERE Product_id = @ProductId";

         using (var con = NewConnection){
            var res = await con.ExecuteAsync(query, new{ProductId});
        
           return res == 1;
        }
    }

    


    public async Task<List<Products>> GetList()
    {
        var query = $@"SELECT * FROM {TableNames.products}";

        using (var con = NewConnection)
            return (await con.QueryAsync<Products>(query)).AsList();
    }

    public async Task<Products> GetById(long ProductId)
    {
        var query = $@"SELECT * FROM {TableNames.products} 
        WHERE Product_id = @ProductId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Products>(query, new { ProductId });
    }

    public async Task<List<Products>> GetListByOrderId(long OrderId)
    {
        var query =$@"SELECT *FROM {TableNames.order_product} op
        LEFT JOIN {TableNames.products} p ON p.product_id = op.product_id
        WHERE op.order_id = @OrderId";

        using (var con = NewConnection)

        return(await con.QueryAsync<Products>(query,new {OrderId})).AsList();
    }
} 