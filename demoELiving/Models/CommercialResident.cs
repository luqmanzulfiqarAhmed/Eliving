using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{[BsonIgnoreExtraElements]

public class CommercialResident:ServiceUsers {

        [BsonElement("commercialResidentId")]
        public string commercialResidentId { get; set; }
       [BsonElement("name")]
        public string name { get; set; }
       [BsonElement("age")]
        public string age { get; set; }
        [BsonElement("gender")]
        public string gender { get; set; }
        [BsonElement("HousingSocietyID")]
        public string housingSocietyID { get; set; }
        

        public CommercialResident(){

        }

}

}