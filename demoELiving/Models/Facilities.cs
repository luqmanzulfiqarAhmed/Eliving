using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    
    public interface Facilities {

        [BsonElement("facilitiesId")]
         string facilitiesId { get ; set ; }
         [BsonElement("societyId")]
        string societyId { get; set; }
        [BsonElement("residentId")]
        string residentId { get; set; }

    }

}