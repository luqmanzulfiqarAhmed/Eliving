
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{

[BsonIgnoreExtraElements]
    public class Vehicle
    {
        [BsonElement("societyId")]
        public string societyId { get; set; }
        [BsonElement("vehicalNo")]
        public string vehicalNo { get; set; }
        [BsonElement("vehicalType")]
        public string vehicalType { get; set; }

        [BsonElement("modelYear")]
        public string modelYear { get; set; }
        [BsonElement("passengerCapacity")]
        public string passengerCapacity { get; set; }
        [BsonElement("vehicalDescription")]
        public string vehicalDescription { get; set; }

        public Vehicle(){}


    }


}