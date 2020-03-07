using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class Society {

        [BsonElement("societyId")]
        public string societyId { get; set; }

        
        [BsonElement("adminEmail")]
        public string adminEmail { get; set; }
        
        [BsonElement("societyName")]
        public string societyName { get; set; }
        [BsonElement("societyFacilities")]
        public string societyFacilities { get; set; }

        [BsonElement("societyLocation")]
        public string societyLocation { get; set; }



        //private Admin societyAdmin; 

        //public Society(Admin admin){
        //        societyAdmin = admin;
        //}   
        // the above is comented because i think we do not need to implement design pattern,which describes the creation of object here 

        public Society() { 
        }


}

}