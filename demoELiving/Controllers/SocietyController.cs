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
        public async Task<ActionResult<Society>> registerSociety(Society society)
        {
            
            await context.insert(society);
            return CreatedAtAction("SocietyRegister", new Society { SocietyID = society.SocietyID }, society);//just telling that society is registered with this id
        }
        [HttpGet("{id}", Name = "SocityData")]
        public async Task<string> getSocityData(string id)
        {
            var societyData = await context.retrieve(id);
            if (societyData == null)
                return null;
            return JsonConvert.SerializeObject(societyData);
        }
        [HttpPut( Name = "UpdateProfileSociety")]
        public async Task <ActionResult> updateAdminProfile(string adminId, string societyId, Society society)
        {
            if (adminId != society.adminEmail && societyId != society.SocietyID)
            {
                return BadRequest();
            }

            await context.update(societyId, society);
            return NoContent();
        }




    }

}