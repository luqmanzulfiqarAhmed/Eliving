using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using demoELiving.Repositires;
using demoELiving.Models;
using Newtonsoft.Json;
namespace demoELiving.Controllers
{
    
    [Route("api/Society")]
    [ApiController]
    public class SocietyController : ControllerBase
    {
        private readonly SocietyRepositry context;

        public SocietyController(SocietyRepositry societyRepositry)
        {
            context = societyRepositry;
        }

        [HttpPost(Name = "SocietyRegister")]
        public async Task <bool > registerSociety([FromBody]Society society)
        {
                     
            
            var societyData = await context.retrieve(society.societyId);
            societyData= JsonConvert.SerializeObject(societyData);
            if (societyData.ToString() == "[]")
            {
                 await context.insert(society);
                 //adminData = (Admin)adminData;
                 return true;
            }
            
            return false;
        }
        [HttpGet("{id}", Name = "SocityData")]
        public async Task<IActionResult> getSocityData(string id)
        {
            var societyData = await context.retrieve(id);
            if (societyData == null)
                return null;
            return Ok(societyData);
        }
        [HttpPut( Name = "UpdateProfileSociety")]
        public async Task <bool> updateSocietyProfile(string adminEmail, string societyId, Society society)
        {
            if (adminEmail != society.adminEmail && societyId != society.societyId)
            {
                return true;
            }

            await context.update(societyId, society);
            return false;
        }




    }

}