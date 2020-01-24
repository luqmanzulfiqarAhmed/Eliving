using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class ManageBill :Facilities{

        public ManageBill() { 
        }
        
        [BsonElement("facilitiesId")]
        public string facilitiesId { get ; set ; }
        [BsonElement("manageBillID")]
        public string manageBillID { get ; set ; }
        [BsonElement("residentId")]
        public string residentId { get; set; }
        [BsonElement("bill_Id")]
        public string bill_Id { get; set; }
        [BsonElement("adminId")]

        public string adminId { get; set; }
        [BsonElement("societyId")]
        public string societyId { get; set; }
        [BsonElement("perUnitPrice")]
        public string perUnitPrice { get; set; }
        [BsonElement("unitConsume")]
        public string unitConsume { get; set; }
        [BsonElement("billStatus")]
        public string billStatus { get; set; }
        [BsonElement("totalPrice")]        
        public string totalPrice { get; set; }
        

        public void calculateBill() {
            
        
        }
        
    }


}