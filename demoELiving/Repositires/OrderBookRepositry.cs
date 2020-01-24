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

    public class OrderBookRepositry : InterfaceDataBase
    {
        private MongoDbContext dbContext = null;
        private IMongoDatabase database;
        public OrderBookRepositry(IConfiguration config)
        {


        dbContext = MongoDbContext.getMongoDbContext(config);
            collection = dbContext.getDataBase().GetCollection<OrderBook>("OrderBooks");
        }
        private readonly IMongoCollection<OrderBook> collection;
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object admin)
        {
            await collection.InsertOneAsync((OrderBook)admin);

            return true;
        }

        public async Task<object> retrieve(string id)
        {
            var admin = Builders<OrderBook>.Filter.Eq("srId", id);

            return await collection.Find(admin).ToListAsync();
        }

        //as we are retriving all societies 
        public async Task<object> retrieveAll(string str)
        {

            return await collection.Find(x => true).ToListAsync();
        }

        public async Task<object> update(string srid, object admin)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.orderBookID == srid, (OrderBook)admin);
            return true;
        }

    }

}
