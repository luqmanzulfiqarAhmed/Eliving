using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class ManageComplain
    {
        public ManageComplain()
        {
        }

        [BsonElement("complaintId")]
        public string  complaintId { get; set; }


        [BsonElement("complaintRemarks")]
        public string complaintRemarks { get; set; }
        [BsonElement("societyId")]
        public string societyId { get; set; }
        [BsonElement("residentEmail")]
        public string residentEmail { get; set; }
        [BsonElement("date")]
        public string date { set; get; }
        [BsonElement("time")]
        public string time { set; get; }
        [BsonElement("userName")]
        public string userName { set; get; }
        [BsonElement("subjectComplaint")]
        public string subjectComplaint { set; get; }
        [BsonElement("descriptionComplaint")]
        public string descriptionComplaint { set; get; }
        
        [BsonElement("statusComplaint")]
        public string statusComplaint { set; get; }

    }


}