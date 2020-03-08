
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using demoELiving.Repositires;
using demoELiving.Models;
using Newtonsoft.Json;

namespace demoELiving.Controllers
{
    
    [Route("api/Anouncement")]
    [ApiController]

    public class AnouncementController : ControllerBase
    {
        private readonly AnouncementRepositry context;

        public AnouncementController(AnouncementRepositry anouncementRepositry)
        {
            context = anouncementRepositry;
        }
        [HttpGet]
        public async Task<string> getAllAnouncementsData()
        {

            var anouncementData = await context.retriveAllData();
            return JsonConvert.SerializeObject(anouncementData);
            
        }
         //http://localhost:5000/api/Anouncement/1       
        [HttpGet("{id}", Name = "AnouncementProfile")]
        public async Task<string> getAnouncementData(string id)
        {
            var anouncementData = await context.retrieve(id);
            if (anouncementData == null)
                return null;
            return JsonConvert.SerializeObject(anouncementData);        
        }

        [HttpPost(Name = "AnouncementRegister")]
        public async Task <bool > registerAnouncement([FromBody]Anouncement anouncement)//ActionResult<Anouncement>

        {            
            var anouncementData = await context.retrieve(anouncement.anouncementEmail);
                                

            anouncementData= JsonConvert.SerializeObject(anouncementData);
            if (anouncementData.ToString() == "[]")
            {
                 await context.insert(anouncement);                 
                 
                 return true;
            }
            
            return false;
        }
         

        
        [HttpPut]
        public async Task <ActionResult> updateAnouncementProfile( [FromBody]Anouncement anouncement)
         {
            
        
           await context.update(anouncement.anouncementEmail, anouncement);
            return Ok(anouncement);
        }
    }
}
    