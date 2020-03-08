using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class ManageBill 
    {
        public ManageBill()
        {
        }
        [BsonElement("gallons")]
          public string gallons { get; set; }
        [BsonElement("MeterNumber")]
            public string MeterNumber { get; set; }
        [BsonElement("propertyId")]
            public string propertyId { get; set; }
        [BsonElement("residentEmail")]
            public string residentEmail { get; set; }
        [BsonElement("issueDate")]
            public string issueDate { get; set; }
        [BsonElement("dueDate")]
            public string dueDate { get; set; }
        [BsonElement("billType")]

            public string billType { get; set; }
        [BsonElement("societyId")]
            public string societyId { get; set; }
        [BsonElement("perUnitPrice")]
            public string perUnitPrice { get; set; }
        [BsonElement("unitConsume")]
            public string unitConsume { get; set; }
        [BsonElement("billId")]
            public string billId { get; set; }
        [BsonElement("billAmount")]
            public string billAmount { get; set; }


        public void calculateBill()
        {


        }

    }


}