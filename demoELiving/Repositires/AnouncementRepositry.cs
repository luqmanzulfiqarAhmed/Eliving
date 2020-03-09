using demoELiving.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoELiving.MongoDB;
using MongoDB.Bson;
namespace demoELiving.Repositires

{
    public class AnouncementRepositry
    {

        private MongoDbContext dbContext = null;
        public AnouncementRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<Anouncement>("Anouncement");//use singletone object to get database 
            //and call that database to get collection of Admin
        }
        private readonly IMongoCollection<Anouncement> collection;

        

        public async Task<bool> insert(object obj)
        {         
            try{  
             Anouncement anouncement = (Anouncement)obj;                                               
                await collection.InsertOneAsync((Anouncement)anouncement);
                return true;
            }catch(Exception ex){
                return false;
            }

        }

        public async Task<object> retrieve(string perssonEmail)
        {
            var anouncement = Builders<Anouncement>.Filter.Eq("perssonEmail", perssonEmail);            
            return  await collection.Find(anouncement).ToListAsync();
        }

        public async Task<object> retrieveAll(string societyId)
        {
            var anouncement = Builders<Anouncement>.Filter.Eq("societyId", societyId);
            return await collection.Find(anouncement).ToListAsync();
        }

        public async Task<object> update(ObjectId id, object anouncement)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.anouncementId == id, (Anouncement)anouncement);
            return true;
        }
    }
}
