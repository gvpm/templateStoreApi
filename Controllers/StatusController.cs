using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Repositories;
using StoreApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using StoreApi.Models.Enums;
using StoreApi.Repositories.Interfaces;
namespace StoreApi.Controllers
{
    //[Route("[controller]")]
    public class StatusController : Controller
    {
 
        public StatusController()
        {
            
        }


        // POST /Product
        [Route("status")]
        [HttpGet]
        public IActionResult Get()
        {
  
            return StatusCode(200,"Online");
        }


    }
}