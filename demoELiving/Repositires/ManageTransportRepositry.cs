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

    public class ManageTransportRepositry 
    {
            private MongoDbContext dbContext = null;
        private IMongoDatabase database;
        public ManageTransportRepositry(IConfiguration config)
        {


        dbContext = MongoDbContext.getMongoDbContext(config);
            collection = dbContext.getDataBase().GetCollection<ManageTransport>("ManageTransports");
        }
        private readonly IMongoCollection<ManageTransport> collection;
        

        public async Task<object> insert(object admin)
        {
            await collection.InsertOneAsync((ManageTransport)admin);

            return true;
        }

        public async Task<object> retrieve(string routeId)
        {
            var transport = Builders<ManageTransport>.Filter.Eq("routeId", routeId);

            return await collection.Find(transport).ToListAsync();
        }

        //as we are retriving all societies 
        public async Task<object> retrieveAll(string societyId)
        {

            return await collection.Find(x => x.societyId == societyId ).ToListAsync();
        }

        public async Task<object> update(string routeId, object transport)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.routeId == routeId, (ManageTransport)transport);
            return true;
        }

    }

}
