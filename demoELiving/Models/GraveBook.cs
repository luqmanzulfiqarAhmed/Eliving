using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class GraveBook 
    {
        

        [BsonElement("graveBookId")]
        public string graveBookId { get ; set ; }

        [BsonElement("societyId")]
        public string societyId { get ; set ; }
        public GraveBook() { }
        
        [BsonElement("propertyId")]
        public string propertyId { get ; set ; }

        [BsonElement("residentId")]
        public string residentId { get ; set ; }

        
        [BsonElement("propertyName")]
        public string propertyName { get ; set ; }

        [BsonElement("graveSize")]
        public string graveSize { get ; set ; }                
        //////
        [BsonElement("graveType")]
        public string graveType { get ; set ; }
        [BsonElement("date")]
        public string date { get ; set ; }
        [BsonElement("time")]
        public string time { get ; set ; }
        [BsonElement("residentName")]
        public string residentName { get ; set ; }
        [BsonElement("residentPhone")]
        public string residentPhone { get ; set ; }
        

        
    }

}