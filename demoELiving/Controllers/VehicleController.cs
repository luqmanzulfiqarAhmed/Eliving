
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
        [HttpGet]
        public async Task<string> getAllVehiclesData()
        {

            var VehicleData = await context.retriveAllData();
            return JsonConvert.SerializeObject(VehicleData);
            
        }
         //http://localhost:5000/api/Vehicle/1       
        [HttpGet("{id}", Name = "VehicleProfile")]
        public async Task<string> getVehicleData(string id)
        {
            var VehicleData = await context.retrieve(id);
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
        [HttpPut("{id}")]
        public async Task <ActionResult> updateVehicleProfile( [FromBody]Vehicle vehicle)
         {
            

           await context.update(vehicle.vehicalNo, vehicle);
            return Ok(vehicle);
        }
    }
}

    