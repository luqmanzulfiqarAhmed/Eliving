using demoELiving.Models;
using demoELiving.MongoDB;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace demoELiving.Repositires
{
    public class HouseResidentRepositry 
    {
            private MongoDbContext dbContext = null;
        
        public HouseResidentRepositry(IConfiguration config)
        {


        dbContext = MongoDbContext.getMongoDbContext(config);
            collection = dbContext.getDataBase().GetCollection<HouseResident>("HouseResidents");
        }
        public async Task<object> retriveAllData()
        {            
            return await collection.Find(x=>true).ToListAsync();
        }
        private readonly IMongoCollection<HouseResident> collection;

        public async Task<object> delete(string id)
        {

            return true;
        }

        public async Task<object> insert(object houseResident)
        {
            await collection.InsertOneAsync((HouseResident)houseResident);

            return true;
        }

        public async Task<object> retrieve(string email)
        {
            
            var houseResident = Builders<HouseResident>.Filter.Eq("email", email);
            

            return await collection.Find(houseResident).ToListAsync();
        }

        public async Task<object> retrieveByemailAndsocietyId(string societyId,string email)
        {
            var houseResident = Builders<HouseResident>.Filter.Eq("housingSocietyID", societyId);
            var houseResidentemail = Builders<HouseResident>.Filter.Eq("email", email);
            var combine = Builders<HouseResident>.Filter.And(houseResident,houseResidentemail);
            return await collection.Find(combine).ToListAsync();
        }
        public async Task<object> retrieveAll(string societyId)
        {
            
        var society = Builders<HouseResident>.Filter.Eq("housingSocietyID", societyId);
        return await collection.Find(society).ToListAsync();
        }
        public async Task<object> update(string id, object houseResident)
        {
            await collection.ReplaceOneAsync(ZZ => ZZ.email == id, (HouseResident)houseResident);
            return true;
        }


    }
}
