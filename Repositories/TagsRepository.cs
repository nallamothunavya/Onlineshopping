using Dapper;
using Onlinepsql.Models;
using Onlinepsql.Utilities;

namespace Onlinepsql.Repositories;

public interface ITagsRepository
{
    
    Task<List<Tags>> GetAllForOders(long TagId);
    Task<Tags> GetById(long TagId);

    Task<List<Tags>> GetList();
}

public class TagsRepository : BaseRepository, ITagsRepository
{
    public TagsRepository(IConfiguration config) : base(config)
    {

    }


    

    public async Task<List<Tags>> GetAllForOders(long TagId)
    {
        var query = $@"SELECT * FROM {TableNames.tags} 
        WHERE Tag_id = @TagId";

        using (var con = NewConnection)
            return (await con.QueryAsync<Tags>(query, new { TagId })).AsList();
    }

   
    public async Task<Tags> GetById(long TagId)
    {
        var query = $@"SELECT * FROM {TableNames.tags} 
        WHERE Tag_id = @TagId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Tags>(query, new { TagId });
    }

    public async Task<List<Tags>> GetList()
    {
       var query = $@"SELECT * FROM {TableNames.tags}";

        using (var con = NewConnection)
            return (await con.QueryAsync<Tags>(query)).AsList();
    }

    
  
}