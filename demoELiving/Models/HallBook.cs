using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class HallBook
    {
        [BsonId]
        public ObjectId hallBookId { get; set; }


        [BsonElement("reservationStatus")]
        public string reservationStatus { get; set; }
        [BsonElement("numberOfPersons")]
        public string numberOfPersons { get; set; }
        [BsonElement("reservationDate")]
        public string reservationDate { get; set; }
        [BsonElement("hallTime")]
        public string hallTime { get; set; }
        public HallBook() { }

        [BsonElement("societyId")]
        public string societyId { get; set; }
        [BsonElement("propertyId")]
        public string propertyId { get; set; }
        [BsonElement("residentId")]
        public string residentId { get; set; }

        [BsonElement("residentName")]
        public string residentName { get; set; }
        [BsonElement("residentPhone")]
        public string residentPhone { get; set; }

        [BsonElement("reservationType")]
        public string reservationType { get; set; }
    }

}