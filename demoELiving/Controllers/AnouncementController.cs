
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
        [HttpGet("{societyId}", Name = "AllAnouncementProfile")]
        public async Task<string> getAllAnouncementsData(string societyId)
        {

            var anouncementData = await context.retrieveAll(societyId);
            return JsonConvert.SerializeObject(anouncementData);
            
        }
         //http://localhost:5000/api/Anouncement/1       
        [HttpGet("{perssonEmail}/{sid}", Name = "AnouncementProfile")]
        public async Task<string> getAnouncementData(string perssonEmail,string sId)
        {
            var anouncementData = await context.retrieve(perssonEmail);
            if (anouncementData == null)
                return null;
            return JsonConvert.SerializeObject(anouncementData);        
        }

        [HttpPost(Name = "AnouncementRegister")]
        public async Task <bool > registerAnouncement([FromBody]Anouncement anouncement)//ActionResult<Anouncement>

        {            
                                                                    
                bool flag= await context.insert(anouncement);                 
                 
                 return flag;
            
            
            
        }
         

        
        [HttpPut]
        public async Task <ActionResult> updateAnouncementProfile( [FromBody]Anouncement anouncement)
         {
            
        
           await context.update(anouncement.anouncementId, anouncement);
            return Ok(anouncement);
        }
    }
}
    