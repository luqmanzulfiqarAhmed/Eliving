using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class ManageTransport {
       public ManageTransport() { 
        }


        [BsonElement("societyId")]
        public string societyId { get ; set ; }
        [BsonElement("routeId")]
        public string routeId { get ; set ; }
        [BsonElement("vehicalNumber")]
        public string vehicalNumber { get ; set ; }        
        [BsonElement("driverPhoneNo")]
        public string driverPhoneNo { get ; set ; }
        [BsonElement("drivertName")]        
        public string drivertName { get; set; }        
        [BsonElement("departurelocation")]
        public string departurelocation { get; set; }        
        [BsonElement("arrivallocation")]
        public string arrivallocation { get; set; }       
        [BsonElement("departureTime")]
        public string departureTime { get; set; }        
        [BsonElement("arrivalTime")]
        public string arrivalTime{ get; set; }
        [BsonElement("busStop")]
        public string busStop{ get; set; }
                
    }

}