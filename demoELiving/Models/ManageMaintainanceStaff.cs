using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace demoELiving.Models{
[BsonIgnoreExtraElements]
public class ManageMaintainanceStaff{


//   Created 6:19 AM6:19 AM
// $mStaffFirstName = $request->input('mStaffFirstName');
// $mStaffLastName = $request->input('mStaffLastName');
// $mStaffCNIC = $request->input('mStaffCNIC');
// $mStaffPhoneNo = $request->input('mStaffPhoneNo');
// $mStaffEmail = $request->input('mStaffEmail');
// $mStaffType = $request->input('mStaffType');
// $mStaffExperience = $request->input('mStaffExperience');
// $mStaffhomeAddress = $request->input('mStaffhomeAddress');
// $mStaffDescription = $request->input('mStaffDescription');
// $DateofBirth = $request->input('DateofBirth');

        [BsonElement("societyId")]
        public string societyId { get; set; }
        
            [BsonElement("StaffFirstName")]
        public string StaffFirstName { get; set; }
              
            [BsonElement("employeeEmail")]
      public string employeeEmail { get ; set ; }


            [BsonElement("mStaffLastName")]
      public  string mStaffLastName { get; set; }
            [BsonElement("mStaffCNIC")]
      public  string mStaffCNIC { get; set; }

            [BsonElement("mStaffPhoneNo")]
       public string mStaffPhoneNo { get; set; }
            [BsonElement("mStaffType")]
      public  string mStaffType { get; set; }
            [BsonElement("mStaffEmail")]
      public  string mStaffEmail { get; set; }

            [BsonElement("mStaffhomeAddress")]
      public  string mStaffhomeAddress { get; set; }
    //         [BsonElement("mStaffDescription")]
    //  public   string mStaffDescription { get; set; }
            [BsonElement("DateofBirth")]
     public   string DateofBirth { get; set; }



}


}