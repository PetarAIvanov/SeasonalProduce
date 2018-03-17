using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP.DataModel;

namespace SP.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/FoodItems")]
    public class FoodItemsController : Controller
    {
        private readonly SeasonalProduceContext context;

        public FoodItemsController(SeasonalProduceContext context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<FoodData> Get()
        {
            return context.FoodDataItems.Include(x => x.Category);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<FoodData> Get(int id)
        {
            return await context.FoodDataItems.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}