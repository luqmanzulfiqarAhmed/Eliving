
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
        [HttpGet("{sid}", Name = "AllAnouncementProfile")]
        public async Task<string> getAllAnouncementsData(string sId)
        {

            var anouncementData = await context.retrieveAll(sId);
            return JsonConvert.SerializeObject(anouncementData);
            
        }
         //http://localhost:5000/api/Anouncement/1       
        [HttpGet("{aid}/{sid}", Name = "AnouncementProfile")]
        public async Task<string> getAnouncementData(string aid,string sId)
        {
            var anouncementData = await context.retrieve(aid);
            if (anouncementData == null)
                return null;
            return JsonConvert.SerializeObject(anouncementData);        
        }

        [HttpPost(Name = "AnouncementRegister")]
        public async Task <bool > registerAnouncement([FromBody]Anouncement anouncement)//ActionResult<Anouncement>

        {            
            var anouncementData = await context.retrieve(anouncement.anouncementId);
                                

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
            
        
           await context.update(anouncement.anouncementId, anouncement);
            return Ok(anouncement);
        }
    }
}
    