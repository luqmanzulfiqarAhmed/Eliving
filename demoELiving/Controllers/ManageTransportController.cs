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

        [HttpGet("{routeId}/{societyId}", Name = "TransportData")]
        public async Task<string> getTransportData(string routeId,string societyId)
        {

            var transportData = await context.retrieve(routeId);
            if (transportData == null)
                return null;
            return JsonConvert.SerializeObject(transportData);
        }

        [HttpPost(Name = "uploadSchdule")]
        public async Task<ActionResult<ManageTransport>> uploadSchdule( [FromBody]ManageTransport manageTransport)
        {
            
                await context.insert(manageTransport);
                return CreatedAtAction("uploadSchdule", new ManageTransport { routeId = manageTransport.routeId}, manageTransport);            
        }

        [HttpPut(Name = "updateSchdule")]
        public async Task<ActionResult> updateSchdule([FromBody]ManageTransport manageTransport)
        {
            
            
            await context.update(manageTransport.routeId,manageTransport);
            return NoContent();
        }

    }
}