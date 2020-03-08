using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class HouseResident {
        
        

       
        [BsonElement("housingSocietyID")]
        public string housingSocietyID { get; set; }
        [BsonElement("residentName")]
        public string residentName { get; set; }
       [BsonElement("residentAge")]
        public string residentAge { get; set; }
        [BsonElement("propertyId")]
        public string propertyId { get; set; }
        [BsonElement("address")]
        public string address { get; set; }
        [BsonElement("password")]
        public string password { get; set; }
        [BsonElement("phone")]
        public string phone { get; set; }
        [BsonElement("email")]
        public string email { get; set; }
        
        public HouseResident(){}
            
    }
}