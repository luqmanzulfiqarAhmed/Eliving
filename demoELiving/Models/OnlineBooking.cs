using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    
    public interface OnlineBooking {
        
       [BsonElement("onlineBookingID")]
         string onlineBookingID { get ; set ; }
         [BsonElement("societyId")]
       string societyId { get; set; }
       [BsonElement("residentId")]
       string residentId { get; set; }

    }

}