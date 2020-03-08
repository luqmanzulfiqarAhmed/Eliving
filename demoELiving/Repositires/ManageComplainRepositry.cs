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

        public async Task<bool> insert(object admin)
        {
            try{
             await collection.InsertOneAsync((ManageComplain)admin);
            return true;
            }
            catch(Exception e){
                    return false;
            }
        }

        public async Task<object> retrieve(string id)
        {
            var admin = Builders<ManageComplain>.Filter.Eq("complainId", id);

            return await collection.Find(admin).ToListAsync();
        }

        //as we are retriving all societies 
        public async Task<object> retrieveAll(string str)
        {

            return await collection.Find(x => true).ToListAsync();
        }

        public async Task<object> update(string id, object admin)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.complainId == id, (ManageComplain)admin);
            return true;
        }

    }

}
