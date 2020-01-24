using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class ManageComplain : Facilities{
       public ManageComplain() { 
        }
        
        [BsonElement("facilitiesId")]
        public string facilitiesId { get ; set ; }
        [BsonElement("manageComplainID")]
        public string manageComplainID { get ; set ; }
        [BsonElement("complainId")]
        public string complainId { set; get; }
        [BsonElement("residentId")]
        public string residentId { set; get; }
        [BsonElement("adminId")]
        public string adminId    { set; get; }
        [BsonElement("societyId")]
        public string societyId  { set; get; }
        [BsonElement("complainStatus")]
        public string complainStatus  { set; get; }
        [BsonElement("complainSubject")]
        public string complainSubject { set; get; }
        [BsonElement("complainDetails")]
        public string complainDetails { set; get; }
        
    }


}