using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
[BsonIgnoreExtraElements]
    public class EmergencyResponse : Facilities {
        public EmergencyResponse() { }
        [BsonElement("facilitiesId")]
        public string facilitiesId { get; set ; }
        [BsonElement("emergencyResponseId")]
        public string emergencyResponseId { get ; set ; }
        [BsonElement("societyId")]
        public string societyId { get; set ; }

        [BsonElement("residentId")]
        public string residentId { get ; set ; }
        [BsonElement("driverId")]
        public string driverId { get; set; }
        [BsonElement("vehicleNumber")]
        public string vehicleNumber { get; set; }
        [BsonElement("status")]
        public string status { get; set; }
        
    }

}