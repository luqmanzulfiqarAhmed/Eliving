
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoELiving.Models;
using demoELiving.MongoDB;

namespace demoELiving.Repositires
{
    public class ManageBillRepositry : InterfaceDataBase
    {

            private MongoDbContext dbContext = null;
        
        public ManageBillRepositry(IConfiguration config)
        {


        dbContext = MongoDbContext.getMongoDbContext(config);
            manageBill = dbContext.getDataBase().GetCollection<ManageBill>("ManageBills");
        }


        private readonly IMongoCollection<ManageBill> manageBill;
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object admin)
        {
            await manageBill.InsertOneAsync((ManageBill)admin);

            return true;
        }

        public async Task<object> retrieve(string id)
        {
            var admin = Builders<ManageBill>.Filter.Eq("billId", id);

            return await manageBill.Find(admin).ToListAsync();
        }

        public async Task<object> retrieveAll(string societyId)
        {
            var bill = Builders<ManageBill>.Filter.Eq("societyId", societyId);
            return await manageBill.Find(bill).ToListAsync();
        }

        public async Task<object> update(string id, object bill)
        {
            await manageBill.ReplaceOneAsync(ZZ => ZZ.billId == id, (ManageBill)bill);
            return true;
        }
    }

}
