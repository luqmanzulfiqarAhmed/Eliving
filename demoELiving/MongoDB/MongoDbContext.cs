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
@"mongodb://smarsocietdb:OKifU92PfSKV8fLHs3gcNI9T58lc5NrzYwT7zwmJPwzUNqc6fDz00fbdvGs8iNDXBUEUtSx3LnVOloouJii6fg==@smarsocietdb.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
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
