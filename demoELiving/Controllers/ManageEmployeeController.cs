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

        [HttpGet("{id}", Name = "EmployeeData")]
        public async Task<string> getEmployeeData(string id)
        {

            var employeeData = await context.retrieve(id);
            if (employeeData == null)
                return null;
            return JsonConvert.SerializeObject(employeeData);
        }

        [HttpPost("{societyID},{manageEmployee}", Name = "uploadEmployee")]
        public async Task<ActionResult<ManageTransport>> uploadEmployee(string societyID, ManageEmployee manageEmployee)
        {
            if (societyID == manageEmployee.societyId)
            {

                await context.insert(manageEmployee);
                return CreatedAtAction("uploadSchdule", new ManageEmployee { employeeEmail = manageEmployee.employeeEmail}, manageEmployee);//just telling that this HouseResident is registered with this id
            }
            return BadRequest();
        }

        [HttpPut( Name = "updateEmployee")]
        public async Task<ActionResult> updateEmployee(string adminId, string societyId, ManageEmployee manageEmployee)
        {
            if (adminId != manageEmployee.employeeEmail && societyId != manageEmployee.societyId)
            {
                return BadRequest();
            }

            await context.update(adminId, manageEmployee);
            return NoContent();
        }


    }
}