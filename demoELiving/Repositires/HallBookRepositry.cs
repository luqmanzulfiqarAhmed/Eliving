using demoELiving.Models;
using demoELiving.MongoDB;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoELiving.Repositires
{

    public class HallBookRepositry 
    {
            private MongoDbContext dbContext = null;
        
        public HallBookRepositry(IConfiguration config)
        {


        dbContext = MongoDbContext.getMongoDbContext(config);
            collection = dbContext.getDataBase().GetCollection<HallBook>("HallBooks");
        }
        private readonly IMongoCollection<HallBook> collection;
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<bool> insert(object hallBook)
        {
            try{
            await collection.InsertOneAsync((HallBook)hallBook);
            return true;
            }
            catch(Exception ex){
            return false;
            }
        }

        public async Task<object> retrieve(string id)
        {
            var admin = Builders<HallBook>.Filter.Eq("srId", id);

            return await collection.Find(admin).ToListAsync();
        }

        //as we are retriving all societies 
        public async Task<object> retrieveAll(string residentId)
        {

            return await collection.Find(x => x.residentId == residentId).ToListAsync();
        }

        public async Task<object> update(string srid, object admin)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.hallBookId == srid, (HallBook)admin);
            return true;
        }

    }

}
