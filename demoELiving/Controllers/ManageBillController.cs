using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using demoELiving.Repositires;
using demoELiving.Models;
using Newtonsoft.Json;

namespace demoELiving.Controllers
{
    [Route("api/ManageBill")]
    [ApiController]
    public class ManageBillController : ControllerBase
    {
        private ManageBillRepositry context;
        public ManageBillController(ManageBillRepositry billRepositry) {
            context = billRepositry;
        }

        [Route("[action]/{societyId}")]
        [HttpGet("{societyId}/{adminID}", Name = "AllHouseResidentBillData")]
        public async Task<string> getAllHouseResidentBillData(string societyId,string adminID)
        {
            var billData = await context.retrieveAll(societyId);
            return JsonConvert.SerializeObject(billData);
        }

        [Route("[action]/{id}")]
        [HttpGet("{id}", Name = "ResidentBill")]
        public async Task<string> getResidentBill(string billId)
        {

            var billData = await context.retrieve(billId);
            if (billData == null)
                return null;
            return JsonConvert.SerializeObject(billData);
        }

        [HttpPost( Name = "submitBill")]
        public async Task<ActionResult<ManageBill>> submitBill([FromBody] ManageBill bill)
        {            
                //here first i will call 'calculateBill' function using bill object
                await context.insert(bill);
                return CreatedAtAction("submitBill", new ManageBill { billId = bill.billId }, bill);//just telling that this HouseResident is registered with this id            
            
        }
 
        [HttpPut( Name = "updateBillManageBill")]
        public async Task<ActionResult> updateBill([FromBody]ManageBill bill)
        {
            
            await context.update(bill.societyId, bill);
            return Ok();
        }

    }
}