using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using demoELiving.Repositires;
using Newtonsoft.Json;
using demoELiving.Models;

namespace demoELiving.Controllers
{
    [Route("api/HouseResident")]
    [ApiController]
    public class HouseResidentController : ControllerBase
    {
        private HouseResidentRepositry context = null;
        public HouseResidentController(HouseResidentRepositry residentRepositry) {
            context = residentRepositry;

        }

        
        [HttpGet("{societyId}/{email}", Name = "AllHouseResidentData")]
        public async Task<string> getAllHouseResidentData(string societyId,string email)
        {
            if (email.Equals("all") )    
            {
            var residentData = await context.retrieveAll(societyId);
            return JsonConvert.SerializeObject(residentData);    
            }
            var residentDataByMail = await context.retrieveByemailAndsocietyId(societyId,email);
            return JsonConvert.SerializeObject(residentDataByMail);
        }

        
        [HttpGet("{email}", Name = "houseResidentProfile")]
        public async Task<string> getHouseResidentProfile(string email)
        {

            var houseResidentData = await context.retrieve(email);
            if (houseResidentData == null)
                return null;
            return JsonConvert.SerializeObject(houseResidentData);
        }

        
        [HttpPost(Name = "registerHouseResident")]
        public async Task <bool> registerHouseResident([FromBody]HouseResident houseResident)
        {                                      
        var residentData = await context.retrieve(houseResident.email);                                
            residentData= JsonConvert.SerializeObject(residentData);
            if (residentData.ToString() == "[]")
            {
                 await context.insert(houseResident);                 
                 
                 return true;
            }
            
            return false;

        }
        [HttpPut( Name = "updateProfilehouseResident") ]
        public async Task <ActionResult> updateAdminProfile([FromBody] HouseResident houseResident)
        {
            
            await context.update(houseResident.email, houseResident);
            return NoContent();        
        }
    }
}