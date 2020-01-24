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

    public class EmergencyResponseRepositry : InterfaceDataBase
    {
            private MongoDbContext dbContext = null;
        
        public EmergencyResponseRepositry(IConfiguration config)
        {



        dbContext = MongoDbContext.getMongoDbContext(config);
            collection = dbContext.getDataBase().GetCollection<EmergencyResponse>("EmergencyResponses");
        }
        private readonly IMongoCollection<EmergencyResponse> collection;
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object admin)
        {
            await collection.InsertOneAsync((EmergencyResponse)admin);

            return true;
        }

        public async Task<object> retrieve(string id)
        {
            var admin = Builders<EmergencyResponse>.Filter.Eq("srId", id);

            return await collection.Find(admin).ToListAsync();
        }

        //as we are retriving all societies 
        public async Task<object> retrieveAll(string str)
        {

            return await collection.Find(x => true).ToListAsync();
        }

        public async Task<object> update(string srid, object admin)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.emergencyResponseId == srid, (EmergencyResponse)admin);
            return true;
        }

    }

}
