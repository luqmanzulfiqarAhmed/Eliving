 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using demoELiving.Repositires;
using Newtonsoft.Json;
using demoELiving.Models;

namespace demoELiving.Controllers
{
    [Route("api/CommercialResident")]
    [ApiController]
    public class CommercialResidentController : ControllerBase
    {
        private CommercialResidentRepositry context;
        public CommercialResidentController(CommercialResidentRepositry residentRepositry) {
            context = residentRepositry;
        }

        [HttpGet]    
        public async Task<string> getAllCommercialResidentsData()
        {

            var CommercialResident = await context.retriveAllData();
            return JsonConvert.SerializeObject(CommercialResident);
            
        }
[Route("[action]/{societyId}")]//in postman http://localhost:5000/api/CommercialResidentAllCommercialResidenttData
        [HttpGet("{societyId}", Name = "AllCommercialResidenttData")]
        public async Task<string> getAllCommercialResidenttData(string societyId)
        {

            var adminData = await context.retrieveAll(societyId);
            return JsonConvert.SerializeObject(adminData);

        }
[Route("[action]/{id}")]//same as above but change action acordingly
        [HttpGet("{id}", Name = "CommercialResidentProfile")]
        public async Task<string> getCommercialResidentData(string id)
        {
            var adminData = await context.retrieve(id);
            if (adminData == null)
                return null;
            return JsonConvert.SerializeObject(adminData);


        }

        [HttpPost("{commercialResident}", Name = "registerCommercialResident")]
        public async Task< ActionResult<CommercialResident>> registerCommercialResident(object commercialResident)
        {
            var ad = (CommercialResident)commercialResident;
            await context.insert(commercialResident);

            return CreatedAtAction("GetCommandItem", new CommercialResident { commercialResidentId = ad.commercialResidentId }, ad);//just telling that this HouseResident is registered with this id
        }

        [HttpPut(Name = "updateCommercialResidentProfile")]
        public async Task<ActionResult> updateCRProfile(string commercialResidentId, string societyId, CommercialResident commercialResident)
        {
            if (commercialResidentId != commercialResident.commercialResidentId && societyId != commercialResident.housingSocietyID)
            {
                return BadRequest();
            }

           await context.update(commercialResidentId, commercialResident);
            return NoContent();
        }
    }
}
