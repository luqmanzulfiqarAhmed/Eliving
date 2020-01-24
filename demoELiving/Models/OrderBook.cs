using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    //i implement Facilities interface but in business model it extends onlineBooking
    public class OrderBook :Facilities {

        public OrderBook() { 
        }
        
        [BsonElement("facilitiesId")]
        public string facilitiesId { get ; set ; }
        [BsonElement("orderBookID")]
        public string orderBookID { get ; set ; }
        [BsonElement("societyId")]
        public string societyId { get ; set ; }
        [BsonElement("residentId")]
        public string residentId { get ; set ; }
        [BsonElement("orderId")]
        public string orderId{ get ; set ; }
        [BsonElement("commercialResidentId")]
        public string commercialResidentId{ get ; set ; }
        [BsonElement("itemID")]
        public string itemID { get ; set ; }
        [BsonElement("itemQuantity")]
        public string itemQuantity{ get ; set ; }
        [BsonElement("duePrice")]
        public string duePrice{ get ; set ; }//nameing convention
        [BsonElement("dateOfOrder")]
        public string dateOfOrder{ get ; set ; }

}

}