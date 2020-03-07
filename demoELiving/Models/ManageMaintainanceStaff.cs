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

            [BsonElement("StaffFirstName")]
        public string StaffFirstName { get; set; }
              
            [BsonElement("employeeEmail")]
      public string employeeEmail { get ; set ; }


            [BsonElement("mStaffLastName")]
        string mStaffLastName { get; set; }
            [BsonElement("mStaffCNIC")]
        string mStaffCNIC { get; set; }

            [BsonElement("mStaffPhoneNo")]
        string mStaffPhoneNo { get; set; }
            [BsonElement("mStaffType")]
        string mStaffType { get; set; }
            [BsonElement("mStaffEmail")]
        string mStaffEmail { get; set; }

            [BsonElement("mStaffhomeAddress")]
        string mStaffhomeAddress { get; set; }
            [BsonElement("mStaffDescription")]
        string mStaffDescription { get; set; }
            [BsonElement("DateofBirth")]
        string DateofBirth { get; set; }



}


}