﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoELiving.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace demoELiving.Controllers
{
    [Route("api/ManageComplain")]
    [ApiController]
    public class ManageComplainController : ControllerBase
    {
        private Repositires.ManageComplainRepositry context;
        public ManageComplainController(Repositires.ManageComplainRepositry billRepositry) {
            context = billRepositry;            
        }

        [HttpGet("{societyId}/{st}", Name = "AllComplainsData")]
        public async Task<string> getAllComplainsData(string societyId,string st)
        {
            var complainsData = await context.retrieveAll(societyId);
            return JsonConvert.SerializeObject(complainsData);
        }

        [HttpGet("{email}", Name = "complain")]
        public async Task<string> getcomplain(string email)
        {

            var complainData = await context.retrieve(email);
            if (complainData == null)
                return null;
            return JsonConvert.SerializeObject(complainData);
        }

        [HttpPost(Name = "submitComplain")]
        public async Task<bool> submitComplain([FromBody] ManageComplain complain)
        {
            
                
               bool flag = await context.insert(complain);
                return flag;
            
        }

        [HttpPut(Name = "updateBill")]
        public async Task<ActionResult> updateBill(string adminId, string societyId, ManageComplain complain)
        {
            if (adminId != complain.adminId && societyId != complain.societyId)
            {
                return BadRequest();
            }
            //here first i will call 'calculateBill' function using bill object to update bill
            await context.update(adminId, complain);
            return NoContent();
        }

    }
}