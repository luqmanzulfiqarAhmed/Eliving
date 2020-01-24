using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoELiving.MongoDB
{
    public class MongoDbContext
    {

        private IMongoDatabase database =null;
        private static MongoDbContext mongoDb=null;
        private MongoDbContext(IConfiguration config)
        {

            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("HousingSocietyAppBuilder");

        }
        public static MongoDbContext getMongoDbContext(IConfiguration config) {

            if (mongoDb == null) {
                mongoDb = new MongoDbContext(config);
            }
            return mongoDb;
        }
        public IMongoDatabase getDataBase() {
            return database;
        }


    }
}
