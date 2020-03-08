using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using demoELiving.Models;
namespace demoELiving.Controllers
{
    [Route("api/ManageEmployee")]
    [ApiController]
    public class ManageEmployeeController : ControllerBase
    {
        private Repositires.ManageEmployeeRepositry context;
        public ManageEmployeeController(Repositires.ManageEmployeeRepositry employeeRepositry)
        {
            context = employeeRepositry;
        }

        [HttpGet("{societyId}", Name = "AllEmployeeData")]
        public async Task<string> getAllEmployeeData(string societyId)
        {
            var employeeData = await context.retrieveAll(societyId);
            return JsonConvert.SerializeObject(employeeData);
        }

         [HttpGet("{societyId}/{designation}", Name = "EmployeeData")]
        public async Task<string> getEmployeeData(string societyId,string designation)
        {
            var employeeData = await context.retrieve(societyId,designation);
            return JsonConvert.SerializeObject(employeeData);
        }

        [HttpPost( Name = "registerEmployee")]
        public  async Task <bool> registerEmployee([FromBody] ManageEmployee manageEmployee)
        {            
            var manageEmployeeData = await context.retrieveByEmail(manageEmployee.employeeEmail);
            manageEmployeeData= JsonConvert.SerializeObject(manageEmployeeData);
            if (manageEmployeeData.ToString() == "[]")
            {
                 await context.insert(manageEmployee);                 
                 return true;
            }
            
            return false;

                
        }

        [HttpPut( Name = "updateEmployee")]
        public async Task<ActionResult> updateEmployee( [FromBody]ManageEmployee manageEmployee)
        {            

            await context.update(manageEmployee.employeeEmail, manageEmployee);
            return NoContent();
        }


    }
}