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
    public class VehicleRepositry: InterfaceDataBase
    {

        private MongoDbContext dbContext = null;
        public VehicleRepositry(IConfiguration config)
        {

            dbContext = MongoDbContext.getMongoDbContext(config);//geting singletone object of database
            collection = dbContext.getDataBase().GetCollection<Vehicle>("Vehicle");//use singletone object to get database 
            //and call that database to get collection of Vehicle
        }
        private readonly IMongoCollection<Vehicle> collection;

          
        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object obj)
        {           
             Vehicle vehicle = (Vehicle)obj;                                               
                await collection.InsertOneAsync((Vehicle)vehicle);
                return true;

        }

        public async Task<object> retrieve(string vehicleId)
        {
            var vehicle = Builders<Vehicle>.Filter.Eq("vehicalNo", vehicleId);            
            return  await collection.Find(vehicle).ToListAsync();
        }

        public async Task<object> retrieveAll(string societyId)
        {
            var vehicle = Builders<Vehicle>.Filter.Eq("societyId", societyId);
            return await collection.Find(vehicle).ToListAsync();
        }

        public async Task<object> update(string id, object vehicle)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.vehicalNo == id, (Vehicle)vehicle);
            return true;
        }
    }
}
