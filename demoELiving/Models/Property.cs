using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class Property 
    {


        public Property() { }
        [BsonElement("propertyId")]
        public string propertyId { get ; set ; }
        [BsonElement("societyId")]
        public string societyId { get ; set ; }
        [BsonElement("area")]
        public string area { get ; set ; }

        [BsonElement("address")]
        public string address { get ; set ; }
        [BsonElement("longitude")]
        public string longitude { get ; set ; }
        [BsonElement("latitued")]
        public string latitued { get ; set ; }
    }

}