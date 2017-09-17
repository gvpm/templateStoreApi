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
    [Route("[controller]")]
    public class CartController : Controller
    {
        public ICartRepository _carts { get; set; }
        public CartController(ICartRepository carts)
        {
            _carts = carts;
        }

        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var cart = _carts.Get(id);
            if (cart == null)
            {
                return StatusCode(404, "User not found");
            }
            return new ObjectResult(cart);
        }

        [HttpPost]
        public IActionResult AlterChart([FromBody]ChartInstruction ids)
        {
            ExternalCart response = null;
            if(ids.Operation.Equals("add")){
                  response = _carts.AddProduct(ids.UserId,ids.ProductId);
            }else if(ids.Operation.Equals("remove")){
                response = _carts.RemoveProduct(ids.UserId,ids.ProductId);
            }else {
                return StatusCode(404, "Invalid Operation");
            }
         

            return new OkObjectResult(response);
        }
    }
}