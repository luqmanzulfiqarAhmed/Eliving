using demoELiving.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoELiving.MongoDB;

namespace demoELiving.Repositires
{
    public class CommercialResidentRepositry : InterfaceDataBase
    {

        private MongoDbContext dbContext = null;
        public CommercialResidentRepositry(IConfiguration config)
        {
            
            dbContext = MongoDbContext.getMongoDbContext(config);
            collection = dbContext.getDataBase().GetCollection<CommercialResident>("CommercialResidents");
            
        }
        private readonly IMongoCollection<CommercialResident> collection;
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object commercialResident)
        {
            await collection.InsertOneAsync((CommercialResident)commercialResident);

            return true;
        }

        public async Task<object> retrieve(string id)
        {
            var commercialResident = Builders<CommercialResident>.Filter.Eq("Id", id);

            return await collection.Find(commercialResident).ToListAsync();
        }
        public async Task<object> retriveAllData()
        {            
            return await collection.Find(x=>true).ToListAsync();
        }
        public async Task<object> retrieveAll(string societyId)
        {
            var commercialResident = Builders<CommercialResident>.Filter.Eq("HousingSocietyID", societyId);
            return await collection.Find(commercialResident).ToListAsync();
        }

        public async Task<object> update(string id, object commercialResident)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.commercialResidentId == id, (CommercialResident)commercialResident);
            return true;
        }


    }

}
