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
    public class WishListController : Controller
    {
        public IWishListRepository _wishLists { get; set; }
        public WishListController(IWishListRepository wishLists)
        {
            _wishLists = wishLists;
        }

        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var wishList = _wishLists.Get(id);
            if (wishList == null)
            {
                return StatusCode(404, "User not found");
            }
            return new ObjectResult(wishList);
        }

        [HttpPost]
        public IActionResult AlterWishList([FromBody]ChartInstruction ids)
        {
            Object response = null;
            if(ids.Operation.Equals("add")){
                response = _wishLists.AddProduct(ids.UserId,ids.ProductId);
            }else if(ids.Operation.Equals("remove")){
                response = _wishLists.RemoveProduct(ids.UserId,ids.ProductId);
            }else {
                return StatusCode(404, "Invalid Operation");
            }
         

            return new OkObjectResult(response);
        }
    }
}