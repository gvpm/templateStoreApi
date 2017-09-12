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
    public class UserController : Controller
    {
        public IUserRepository _users { get; set; }
        public UserController(IUserRepository users)
        {
            _users = users;
        }

        // POST /Product
        [Route("user/new")]
        [HttpPost]
        public IActionResult New([FromBody]User p)
        {
            var added = _users.Create(p);

            if (added != null)
            {
                return new OkObjectResult(added);

            }
            
            return StatusCode(409,"Username already registered");
        }

        // POST /Product
        [Route("user/login")]
        [HttpPost]
        public IActionResult Login([FromBody]User p)
        {
            var logged = _users.Login(p);

            if (logged != null)
            {
                return new OkObjectResult(logged);

            }
            return StatusCode(404,"Username not found");
        }


    }
}