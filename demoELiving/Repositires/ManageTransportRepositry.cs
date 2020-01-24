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

    public class ManageTransportRepositry : InterfaceDataBase
    {
            private MongoDbContext dbContext = null;
        private IMongoDatabase database;
        public ManageTransportRepositry(IConfiguration config)
        {


        dbContext = MongoDbContext.getMongoDbContext(config);
            collection = dbContext.getDataBase().GetCollection<ManageTransport>("ManageTransports");
        }
        private readonly IMongoCollection<ManageTransport> collection;
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object admin)
        {
            await collection.InsertOneAsync((ManageTransport)admin);

            return true;
        }

        public async Task<object> retrieve(string id)
        {
            var admin = Builders<ManageTransport>.Filter.Eq("srId", id);

            return await collection.Find(admin).ToListAsync();
        }

        //as we are retriving all societies 
        public async Task<object> retrieveAll(string str)
        {

            return await collection.Find(x => true).ToListAsync();
        }

        public async Task<object> update(string id, object admin)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.manageTransportID == id, (ManageTransport)admin);
            return true;
        }

    }

}
