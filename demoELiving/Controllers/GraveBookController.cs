
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using demoELiving.Repositires;
using demoELiving.Models;
using Newtonsoft.Json;

namespace demoELiving.Controllers
{
    
    [Route("api/GraveBook")]
    [ApiController]

    public class GraveBookController : ControllerBase
    {
        private readonly GraveBookRepositry context;

        public GraveBookController(GraveBookRepositry adminRepositry)
        {
            context = adminRepositry;
        }
        [HttpGet("{societyId}/{propertyName}", Name = "allGraveProfiles")]
        public async Task<string> getAllGravesData(string societyId,string propertyName)
        {
            var graveData = await context.retrieveAll(societyId,propertyName);
            return JsonConvert.SerializeObject(graveData);
            
        }
         
        [HttpGet("{societyId}/{propertyName}/{residentId}", Name = "graveProfile")]
        public async Task<string> getGraveData(string societyId,string propertyName,string residentId)
        {
            var graveData = await context.retrieve(societyId,propertyName,residentId);
            if (graveData == null)
                return null;
            return JsonConvert.SerializeObject(graveData);        
        }

        [HttpPost(Name = "GraveRegister")]
        public async Task <bool > registerGrave([FromBody]GraveBook grave)
        {            
            var graveData = await context.retrieve(grave.societyId,grave.propertyName,grave.residentId);                                
            graveData= JsonConvert.SerializeObject(graveData);
            if (graveData.ToString() == "[]")
            {
                 await context.insert(grave);                 
                 
                 return true;
            }
            
            return false;
        }
         

        
        [HttpPut]
        public async Task <ActionResult> updateAdminProfile( [FromBody]GraveBook grave)
         {
                        
           await context.update(grave.graveBookId, grave);
            return Ok(grave);
        }
    }
}

        