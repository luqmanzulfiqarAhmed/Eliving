using demoELiving.Models;
using demoELiving.MongoDB;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace demoELiving.Repositires
{

    public class GraveBookRepositry : InterfaceDataBase
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

        public async Task<object> retrieve(string id)
        {
            var admin = Builders<GraveBook>.Filter.Eq("srId", id);

            return await collection.Find(admin).ToListAsync();
        }

        //as we are retriving all societies 
        public async Task<object> retrieveAll(string str)
        {

            return await collection.Find(x => true).ToListAsync();
        }

        public async Task<object> update(string srid, object admin)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.graveBookId == srid, (GraveBook)admin);
            return true;
        }

    }

}
