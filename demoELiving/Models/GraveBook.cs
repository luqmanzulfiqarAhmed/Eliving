using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class GraveBook : Facilities
    {

        [BsonElement("facilitiesId")]
        public string facilitiesId { get ; set ; }
        public GraveBook() { }
        [BsonElement("graveBookId")]
        public string graveBookId { get ; set ; }
        [BsonElement("societyId")]
        public string societyId { get ; set ; }
        [BsonElement("residentId")]
        public string residentId { get ; set ; }
        
    }

}