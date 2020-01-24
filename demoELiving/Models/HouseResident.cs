using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class HouseResident : ServiceUsers{
        
        
             
        [BsonElement("houseResidentID")]
        public string houseResidentID { get; set; }
       
        [BsonElement("housingSocietyID")]
        public string housingSocietyID { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
       [BsonElement("age")]
        public string age { get; set; }
        [BsonElement("gender")]
        public string gender { get; set; }

        public HouseResident(){}
            
    }
}