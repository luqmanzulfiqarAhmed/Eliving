using demoELiving.Models;
using demoELiving.MongoDB;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

using System.Threading.Tasks;

namespace demoELiving.Repositires
{

    public class GraveBookRepositry 
    {
            private MongoDbContext dbContext = null;
        
        public GraveBookRepositry(IConfiguration config)
        {


        dbContext = MongoDbContext.getMongoDbContext(config);
            collection = dbContext.getDataBase().GetCollection<GraveBook>("GraveBooks");
        }
        private readonly IMongoCollection<GraveBook> collection;
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object admin)
        {
            await collection.InsertOneAsync((GraveBook)admin);

            return true;
        }

        public async Task<object> retrieve(string societyId,string graveYardName,string residentId)
        {
        var society = Builders<GraveBook>.Filter.Eq(x => x.societyId, societyId);
        var name = Builders<GraveBook>.Filter.Eq(x => x.propertyName,graveYardName);
        var id = Builders<GraveBook>.Filter.Eq(x => x.residentId , residentId);
        var combineFilters = Builders<GraveBook>.Filter.And(society,name,id );

        return await collection.Find(combineFilters).ToListAsync();                               
        }

        //as we are retriving all societies 
        public async Task<object> retrieveAll(string societyId,string graveYardName)
        {
            var society = Builders<GraveBook>.Filter.Eq(x => x.societyId, societyId);
            var name = Builders<GraveBook>.Filter.Eq(x => x.propertyName,graveYardName);
            var combineFilters = Builders<GraveBook>.Filter.And(society,name );

            return await collection.Find(combineFilters).ToListAsync(); 
        }

        public async Task<object> update(string graveBookId, object admin)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.graveBookId == graveBookId, (GraveBook)admin);
            return true;
        }

    }

}
