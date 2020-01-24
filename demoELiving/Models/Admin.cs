using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
 

namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class Admin
    {
        // [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        // public string Id { get; set; }        //this is internal id of mongodb we have our own 
        // i.e adminId we store unique id by using find before registring any admin 
       [BsonElement("adminId")]
        public string adminId { get; set; }
       [BsonElement("name")]
        public string name { get; set; }
      [BsonElement("age")]
        public string age { get; set; }
       [BsonElement("gender")]
        public string gender { get; set; }
      [BsonElement("HousingSocietyID")]
        public string HousingSocietyID { get; set; }

      [BsonElement("password")]
        public string password { get; set; }
        public Admin()
        {

        }
    }
}
