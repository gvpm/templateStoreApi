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
    public class HistoryController : Controller
    {
        public IHistoryRepository _histories { get; set; }
        public HistoryController(IHistoryRepository histories)
        {
            _histories = histories;
        }

        // GET /Product/5
        [HttpGet("{id:length(24)}")]
        public IEnumerable<History> Get(string id)
        {
            return _histories.GetAll(id);
        }

      

    }
}

