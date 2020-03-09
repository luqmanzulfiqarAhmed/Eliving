using demoELiving.Models;
using demoELiving.MongoDB;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
namespace demoELiving.Repositires
{

    public class HallBookRepositry 
    {
            private MongoDbContext dbContext = null;
        
        public HallBookRepositry(IConfiguration config)
        {


        dbContext = MongoDbContext.getMongoDbContext(config);
            collection = dbContext.getDataBase().GetCollection<HallBook>("HallBook");
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

         
        public async Task<object> retrieveAll(string residentId)
        {

            return await collection.Find(x => x.residentId == residentId).ToListAsync();
        }
public async Task<object> retrieve(string societyId,string propertyId)
        {
             
            var resident = Builders<HallBook>.Filter.Eq("societyId", societyId);
            var property = Builders<HallBook>.Filter.Eq("propertyId", propertyId);
            var combine = Builders<HallBook>.Filter.And(resident,property);
            return await collection.Find(combine).ToListAsync();
        }
        public async Task<object> update(ObjectId id, object admin)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.hallBookId == id, (HallBook)admin);
            return true;
        }

    }

}
