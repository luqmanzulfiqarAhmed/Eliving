using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class ManageTransport: Facilities {
       public ManageTransport() { 
        }
        
        [BsonElement("facilitiesId")]
        public string facilitiesId { get ; set ; }
        [BsonElement("manageTransportID")]
        public string manageTransportID { get ; set ; }
        [BsonElement("societyId")]        
        public string societyId { get; set; }
        [BsonElement("adminID")]
        public string adminID { get; set; }
        [BsonElement("busNumber")]
        public string busNumber { get; set; }
        [BsonElement("driverName")]
        public string driverName { get; set; }
        [BsonElement("routeNumber")]
        public string routeNumber{ get; set; }
        [BsonElement("busStopNames")]
        public string busStopNames { get; set; }
        [BsonElement("busStopTiming")]
        public string busStopTiming { get; set; }
        [BsonElement("sittingCapacity")]
        public string sittingCapacity { get; set; }
        [BsonElement("residentId")]
        public string residentId { get ; set; }
    }

}