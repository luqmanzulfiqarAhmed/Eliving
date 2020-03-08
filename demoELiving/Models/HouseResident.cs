using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class HouseResident {
        
        

       
        [BsonElement("housingSocietyID")]
        public string housingSocietyID { get; set; }

        [BsonElement("residentType")]
        public string residentType { get; set; }
        
        [BsonElement("residentFirstName")]
        public string residentFirstName { get; set; }

        [BsonElement("residentLastName")]
        public string residentLastName { get; set; }
        
        [BsonElement("cnic")]
        public string cnic { get; set; }

       [BsonElement("residentDateOfBirth")]
        public string residentDateOfBirth { get; set; }
        [BsonElement("email")]
        public string email { get; set; }

        [BsonElement("phoneNo")]
        public string phoneNo { get; set; }
        
        [BsonElement("propertyId")]
        public string propertyId { get; set; }
        [BsonElement("address")]
        public string address { get; set; }
        [BsonElement("password")]
        public string password { get; set; }
        
        public HouseResident(){}
            
    }
}