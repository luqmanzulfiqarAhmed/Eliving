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
    public class PropertyRepositry
    {
        private MongoDbContext dbContext = null;

        public PropertyRepositry(IConfiguration config)
        {
                                           
        dbContext = MongoDbContext.getMongoDbContext(config);
            collection = dbContext.getDataBase().GetCollection<Property>("Property");
        }
        private readonly IMongoCollection<Property> collection;

        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object society)
        {
            await collection.InsertOneAsync((Property)society);

            return true;
        }

        public async Task<object> retrieve(string pid)
        {
            var society = Builders<Property>.Filter.Eq("propertyId", pid);

            return await collection.Find(society).ToListAsync();
        }

        public async Task<object> retrieveAll(string societyId)
        {
            var society = Builders<Property>.Filter.Eq("societyId", societyId);
            return await collection.Find(society).ToListAsync();
        }

        public async Task<object> update(string id, object society)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.propertyId == id, (Property)society);
            return true;
        }
    }
}
