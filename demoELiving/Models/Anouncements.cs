using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    
    public class Anouncement
    {

        public Anouncement() { }
        
        [BsonElement("anouncementId")]
        public string anouncementId { get; set; }


        [BsonElement("societyId")]
        public string societyId { get; set; }
        
        [BsonElement("perssonEmail")]
        public string perssonEmail { get; set; }

        [BsonElement("personName")]
        public string personName { get; set; }

        [BsonElement("time")]
        public string time { get; set; }

        [BsonElement("date")]
        public string date { get; set; }


        [BsonElement("IPAddress")]
        public string IPAddress { get; set; }

        [BsonElement("subject")]
        public string subject { get; set; }

        [BsonElement("description")]
        public string description { get; set; }



    }

}