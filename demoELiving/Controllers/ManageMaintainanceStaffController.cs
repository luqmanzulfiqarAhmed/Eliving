
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using demoELiving.Repositires;
using demoELiving.Models;
using Newtonsoft.Json;

namespace demoELiving.Controllers
{
    
    [Route("api/MaintainanceStaff")]
    [ApiController]

    public class ManageMaintainanceStaffController : ControllerBase
    {
        private readonly MaintainanceStaffRepositry context;

        public ManageMaintainanceStaffController(MaintainanceStaffRepositry maintainanceRepositry)
        {
            context = maintainanceRepositry;
        }
        [HttpGet]
        public async Task<string> getAllStaffsData()
        {

            var staffData = await context.retriveAllData();
            return JsonConvert.SerializeObject(staffData);
            
        }
         //http://localhost:5000/api/Admin/1       
        [HttpGet("{id}", Name = "staffProfile")]
        public async Task<string> getStaffData(string email)
        {
            var staffData = await context.retrieve(email);
            if (staffData == null)
                return null;
            return JsonConvert.SerializeObject(staffData);        
        }

        [HttpPost(Name = "staffMemberRegister")]
        public async Task <bool > registerStaffMember([FromBody]ManageMaintainanceStaff staff)//ActionResult<Admin>

        {            
            var staffData = await context.retrieve(staff.employeeEmail);
                                

            staffData= JsonConvert.SerializeObject(staffData);
            if (staffData.ToString() == "[]")
            {
                 await context.insert(staff);                 
                 
                 return true;
            }
            
            return false;
        }
         

        //[HttpPut("{adminId},{societyId},{admin}", Name = "UpdateProfileAdmin")]
        [HttpPut]
        public async Task <ActionResult> updateStaffMemberProfile( [FromBody]ManageMaintainanceStaff staff)
         {
                        

           await context.update(staff.employeeEmail, staff);
            return Ok(staff);
        }
    }
}
