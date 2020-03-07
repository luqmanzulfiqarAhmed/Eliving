using demoELiving.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoELiving.MongoDB;
using Newtonsoft.Json;
namespace demoELiving.Repositires

{
    public class MaintainanceStaffRepositry: InterfaceDataBase
    {

        private MongoDbContext dbContext = null;
        public MaintainanceStaffRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<ManageMaintainanceStaff>("collection");//use singletone object to get database 
            //and call that database to get collection of Admin
        }
        private readonly IMongoCollection<ManageMaintainanceStaff> collection;

        public async Task<object> retriveAllData()
        {            
            return await collection.Find(x=>true).ToListAsync();
        }

        //not defined yet because we will not delete in server we only disable particular account
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object obj)
        {           

             ManageMaintainanceStaff staff = (ManageMaintainanceStaff)obj;                                               
                await collection.InsertOneAsync(staff);             
                return true;

        }

        public async Task<object> retrieve(string staffEmail)
        {
            
            var staff = Builders<ManageMaintainanceStaff>.Filter.Eq("employeeEmail", staffEmail);            

            return  await collection.Find(staff).ToListAsync();
        }

        public async Task<object> retrieveAll(string societyId)
        {

            var staff = Builders<ManageMaintainanceStaff>.Filter.Eq("HousingSocietyID", societyId);            

            return await collection.Find(staff).ToListAsync();
        }

        public async Task<object> update(string id, object staff)
        {

            await collection.ReplaceOneAsync(ZZ => ZZ.employeeEmail == id, (ManageMaintainanceStaff)staff);            
            return true;
        }
    }
}
