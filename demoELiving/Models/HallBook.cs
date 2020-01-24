using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class HallBook : Facilities
    {
        public HallBook() { }
        
        [BsonElement("facilitiesId")]
        public string facilitiesId { get ; set ; }
        [BsonElement("hallBookId")]
        public string hallBookId { get ; set ; }
        [BsonElement("societyId")]
        public string societyId { get; set ; }
        [BsonElement("residentId")]
        public string residentId { get ; set ; }

        [BsonElement("DateOfBooking")]
        public string DateOfBooking{ get ; set ; }
        [BsonElement("eventType")]
        public string eventType{ get ; set ; }


}

}