
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    
public interface ServiceUsers{
    
    
        [BsonElement("housingSocietyID")]
         string housingSocietyID { get; set; }
       [BsonElement("name")]
         string name { get; set; }
       [BsonElement("age")]
         string age { get; set; }
        [BsonElement("gender")]
         string gender { get; set; }


    }


}