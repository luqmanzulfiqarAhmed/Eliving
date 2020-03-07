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

    public class ManageEmployeeRepositry : InterfaceDataBase
    {
            private MongoDbContext dbContext = null;
        private IMongoDatabase database;
        public ManageEmployeeRepositry(IConfiguration config)
        {


        dbContext = MongoDbContext.getMongoDbContext(config);
            collection = dbContext.getDataBase().GetCollection<ManageEmployee>("ManageEmployees");
        }
        private readonly IMongoCollection<ManageEmployee> collection;
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object admin)
        {
            await collection.InsertOneAsync((ManageEmployee)admin);

            return true;
        }

        public async Task<object> retrieve(string id)
        {
            var admin = Builders<ManageEmployee>.Filter.Eq("employeeEmail", id);

            return await collection.Find(admin).ToListAsync();
        }

        //as we are retriving all societies 
        public async Task<object> retrieveAll(string societyId)
        {

            var admin = Builders<ManageEmployee>.Filter.Eq("societyId", societyId);
            return await collection.Find(admin).ToListAsync();
        }

        public async Task<object> update(string srid, object admin)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.employeeEmail == srid, (ManageEmployee)admin);
            return true;
        }

    }

}
