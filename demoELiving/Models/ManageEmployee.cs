
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace demoELiving.Models
{
  [BsonIgnoreExtraElements]
    public class ManageEmployee {

      public  ManageEmployee() { }

      
      
        
      
      [BsonElement("employeeEmail")]
      public string employeeEmail { get ; set ; }
      
      [BsonElement("employeeFirstName")]
      public string employeeFirstName { get; set; }
      
      [BsonElement("employeeLastName")]
      public string employeeLastName { get; set; } 
      
      [BsonElement("employeeCNIC")]
      public string employeeCNIC { get; set; } 

      [BsonElement("employeePhoneNo")]
      public string employeePhoneNo { get; set; } 

      [BsonElement("designation")]
      public string designation { get; set; }       
      
      [BsonElement("homeAddress")]
      public string homeAddress { get; set; } 

      [BsonElement("department")]
      public string department { get; set; } 
      
      [BsonElement("employeeDateofBirth")]
      public string employeeDateofBirth { get; set; }
      [BsonElement("societyId")]
      public string societyId { get; set; }
      
       
        
    }

}