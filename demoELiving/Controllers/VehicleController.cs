
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using demoELiving.Repositires;
using demoELiving.Models;
using Newtonsoft.Json;

namespace demoELiving.Controllers
{
    
    [Route("api/Vehicle")]
    [ApiController]

    public class VehicleController : ControllerBase
    {
        private readonly VehicleRepositry context;

        public VehicleController(VehicleRepositry VehicleRepositry)
        {
            context = VehicleRepositry;
        }
        [HttpGet("{societyId}", Name = "allVehicleProfile")]
        public async Task<string> getAllVehiclesData(string societyId)
        {

            var VehicleData = await context.retrieveAll(societyId);
            return JsonConvert.SerializeObject(VehicleData);
            
        }
         
        [HttpGet("{vid}/{societyId}", Name = "VehicleProfile")]
        public async Task<string> getVehicleData(string vid,string societyId)
        {
            var VehicleData = await context.retrieve(vid);
            if (VehicleData == null)
                return null;
            return JsonConvert.SerializeObject(VehicleData);        
        }

        [HttpPost(Name = "VehicleRegister")]
        public async Task <bool > registerVehicle([FromBody]Vehicle vehicle)//ActionResult<Vehicle>

        {            
            var VehicleData = await context.retrieve(vehicle.vehicalNo);
                                

            VehicleData= JsonConvert.SerializeObject(VehicleData);
            if (VehicleData.ToString() == "[]")
            {
                 await context.insert(vehicle);                 
                 
                 return true;
            }
            
            return false;
        }
         

        //[HttpPut("{VehicleId},{societyId},{Vehicle}", Name = "UpdateProfileVehicle")]
        [HttpPut]
        public async Task <ActionResult> updateVehicleProfile( [FromBody]Vehicle vehicle)
         {
            

           await context.update(vehicle.vehicalNo, vehicle);
            return Ok(vehicle);
        }
    }
}

    