
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
  [BsonIgnoreExtraElements]
    public class ManageEmployee:Facilities {

      public  ManageEmployee() { }
      
        [BsonElement("facilitiesId")]
        public string facilitiesId { get ; set ; }
      
      [BsonElement("manageEmployeeID")]
        public string manageEmployeeID { get ; set ; }
        [BsonElement("societyId")]
        public string societyId { get; set; }
        [BsonElement("adminID")]
        public string adminID { get; set; }
        [BsonElement("employeeId")]
        public string employeeId { get; set; }
        [BsonElement("employeeName")]
        public string employeeName{ get; set; }
        [BsonElement("employeeDepartment")]
        public string employeeDepartment{ get; set; }
        [BsonElement("employeePhoneNumber")]
        public string employeePhoneNumber{ get; set; }
        [BsonElement("employeeCNIC")]
        public string employeeCNIC{ get; set; }
        [BsonElement("employeeAddress")]
        public string employeeAddress{ get; set; }
        [BsonElement("residentId")]
        public string residentId { get ; set; }
    }

}