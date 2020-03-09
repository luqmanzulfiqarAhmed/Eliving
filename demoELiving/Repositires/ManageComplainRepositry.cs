using demoELiving.Models;
using demoELiving.MongoDB;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace demoELiving.Repositires
{

    public class ManageComplainRepositry 
    {
            private MongoDbContext dbContext = null;
            
        public ManageComplainRepositry(IConfiguration config)
        {


        dbContext = MongoDbContext.getMongoDbContext(config);
            collection = dbContext.getDataBase().GetCollection<ManageComplain>("ManageComplains");
        }
        private readonly IMongoCollection<ManageComplain> collection;
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<bool> insert(object complain)
        {
            try{
                
             await collection.InsertOneAsync((ManageComplain)complain);
            return true;
            }
            catch(Exception e){
                    return false;
            }
        }

        public async Task<object> retrieve(string email)
        {
            var admin = Builders<ManageComplain>.Filter.Eq("residentEmail", email);

            return await collection.Find(admin).ToListAsync();
        }

        //as we are retriving all societies 
        public async Task<object> retrieveAll(string societyId)
        {

            return await collection.Find(x => x.societyId == societyId).ToListAsync();
        }

        public async Task<object> update(ObjectId complainId, object complain)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.complaintId == complainId, (ManageComplain)complain);
            return true;
        }

    }

}
