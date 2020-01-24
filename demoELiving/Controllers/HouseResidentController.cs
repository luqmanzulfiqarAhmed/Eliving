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
        [HttpGet(Name = "AllResidentsData")]
        public async Task<string> getAllResidentsData()//all residents of each housing society
        {

            var residentData = await context.retriveAllData();
            return JsonConvert.SerializeObject(residentData);
            
        }

        [Route("[action]/{societyId}")]
        [HttpGet("{societyId}", Name = "AllHouseResidentData")]
        public async Task<string> getAllHouseResidentData(string societyId)
        {
            var adminData = await context.retrieveAll(societyId);
            return JsonConvert.SerializeObject(adminData);
        }

        [Route("[action]/{id}")]
        [HttpGet("{id}", Name = "houseResidentProfile")]
        public async Task<string> getHouseResidentProfile(string id)
        {

            var houseResidentData = await context.retrieve(id);
            if (houseResidentData == null)
                return null;
            return JsonConvert.SerializeObject(houseResidentData);
        }


        [HttpPost("{houseResident}", Name = "registerHouseResident")]
        public async Task <ActionResult<HouseResident>> registerHouseResident(HouseResident houseResident)
        {

            
          await  context.insert(houseResident);
            return CreatedAtAction("registerHouseResident", new HouseResident { houseResidentID = houseResident.houseResidentID }, houseResident);//just telling that this HouseResident is registered with this id
        }
        [HttpPut( Name = "updateProfilehouseResident") ]
        public async Task <ActionResult> updateAdminProfile(string houseResidentId, HouseResident houseResident)
        {
            if (houseResidentId != houseResident.houseResidentID)
            {
                return BadRequest();
            }

            await context.update(houseResidentId, houseResident);
            return NoContent();
        }
    }
}