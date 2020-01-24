using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace demoELiving.Models
{
    [BsonIgnoreExtraElements]
    public class Society {

        [BsonElement("societyId")]
        public string SocietyID { get; set; }

        [BsonElement("adminID")]
        public string AdminID { get; set; }
        [BsonElement("societyname")]
        public string Societyname { get; set; }
        [BsonElement("registeredFacilities")]
        public string registeredFacilities { get; set; }
        //public string locations { get; set; }



        //private Admin societyAdmin; 

        //public Society(Admin admin){
        //        societyAdmin = admin;
        //}   
        // the above is comented because i think we do not need to implement design pattern,which describes the creation of object here 

        public Society() { 
        }


}

}