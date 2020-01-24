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
    [Route("api/ManageTransport")]
    [ApiController]
    public class ManageTransportController : ControllerBase
    {
        private Repositires.ManageTransportRepositry context;
        public ManageTransportController(Repositires.ManageTransportRepositry transportRepositry)
        {
            context = transportRepositry;
        }

        [HttpGet("{societyId}", Name = "AllTransportData")]
        public async Task<string> getAllTransportData(string societyId)
        {
            var complainsData = await context.retrieveAll(societyId);
            return JsonConvert.SerializeObject(complainsData);
        }

        [HttpGet("{id}", Name = "TransportData")]
        public async Task<string> getTransportData(string id)
        {

            var transportData = await context.retrieve(id);
            if (transportData == null)
                return null;
            return JsonConvert.SerializeObject(transportData);
        }

        [HttpPost("{residentId},{manageTransport}", Name = "uploadSchdule")]
        public async Task<ActionResult<ManageTransport>> uploadSchdule(string residentId, ManageTransport manageTransport)
        {
            if (residentId == manageTransport.manageTransportID)
            {

                await context.insert(manageTransport);
                return CreatedAtAction("uploadSchdule", new ManageTransport { manageTransportID = manageTransport.manageTransportID}, manageTransport);//just telling that this HouseResident is registered with this id
            }
            return BadRequest();
        }

        [HttpPut(Name = "updateSchdule")]
        public async Task<ActionResult> updateSchdule(string adminId, string societyId, ManageTransport manageTransport)
        {
            if (adminId != manageTransport.adminID && societyId != manageTransport.societyId)
            {
                return BadRequest();
            }
            
            await context.update(adminId, manageTransport);
            return NoContent();
        }

    }
}