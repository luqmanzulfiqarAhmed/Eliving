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
    public class SocietyRepositry : InterfaceDataBase
    {
        private MongoDbContext dbContext = null;

        public SocietyRepositry(IConfiguration config)
        {
                                           
        dbContext = MongoDbContext.getMongoDbContext(config);
            collection = dbContext.getDataBase().GetCollection<Society>("Societies");
        }
        private readonly IMongoCollection<Society> collection;

        //public Admin Create(Admin admin) {
        //    collection.InsertOne(admin);
        //    return admin;
        //}
        //public Admin GetAdmin(string adminID)
        //{
        //    return collection.Find<Admin>(admin => admin.Id == adminID).FirstOrDefault();

        //}
        //public List<Admin> Get() {
        //    return collection.Find(admin => true).ToList();
        //}

        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object society)
        {
            await collection.InsertOneAsync((Society)society);

            return true;
        }

        public async Task<object> retrieve(string id)
        {
            var society = Builders<Society>.Filter.Eq("societyId", id);

            return await collection.Find(society).ToListAsync();
        }

        public async Task<object> retrieveAll(string Id)
        {
            var society = Builders<Society>.Filter.Eq("societyId", Id);
            return await collection.Find(society).ToListAsync();
        }

        public async Task<object> update(string id, object society)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.adminEmail == id, (Society)society);
            return true;
        }
    }
}
