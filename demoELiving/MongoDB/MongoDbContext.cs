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

        private IMongoDatabase database = null;
        private static MongoDbContext mongoDb = null;
        private MongoDbContext(IConfiguration config)
        {
            string connectionString =
  @"mongodb://luqmanahmed:M8k0cDWJS70KUVUpIaXsY2mLpkSmIaO6EpYhteiUwhIHWxZOboncneoLedxlgTFsG5Joe2lwE8f26x7uvtLQng==@luqmanahmed.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@luqmanahmed@";
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);


            database = mongoClient.GetDatabase("HousingSocietyAppBuilder");

        }
        public static MongoDbContext getMongoDbContext(IConfiguration config)
        {

            if (mongoDb == null)
            {
                mongoDb = new MongoDbContext(config);
            }
            return mongoDb;
        }
        public IMongoDatabase getDataBase()
        {
            return database;
        }


    }
}
