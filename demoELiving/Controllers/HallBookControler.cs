
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using demoELiving.Repositires;
using demoELiving.Models;
using Newtonsoft.Json;

namespace demoELiving.Controllers
{

    [Route("api/HallBook")]
    [ApiController]

    public class HallBookController : ControllerBase
    {
        private readonly HallBookRepositry context;

        public HallBookController(HallBookRepositry hallBookRepositry)
        {
            context = hallBookRepositry;
        }
        [HttpGet("{residentId}", Name = "getAllHallBooksData")]
        public async Task<string> getAllHallBooksData(string residentId)
        {

            var HallBookData = await context.retrieveAll(residentId);
            return JsonConvert.SerializeObject(HallBookData);

        }
        [HttpGet("{societyId}/{hallId}", Name = "getHallBooksData")]
        public async Task<string> getHallBooksData(string societyId,string hallId)
        {

            var HallBookData = await context.retrieve(societyId,hallId);
            return JsonConvert.SerializeObject(HallBookData);

        }


        [HttpPost(Name = "HallBookRegister")]
        public async Task<bool> registerHallBook([FromBody]HallBook hallBook)//ActionResult<HallBook>

        {

            
            bool flag = await context.insert(hallBook);
            return flag;



        }

        [HttpPut]
        public async Task<ActionResult> updateHallBookProfile([FromBody]HallBook hallBook)
        {


            await context.update(hallBook.hallBookId, hallBook);
            return Ok(hallBook);
        }
    }
}
