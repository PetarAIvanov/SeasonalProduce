using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP.DataModel;
using SP.WebApi.DTO;

namespace SP.WebApi.Controllers
{
    [Produces("application/json")]
    [EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All)]
    public class FoodDataController : Controller
    {
        private readonly SeasonalProduceContext context;

        public FoodDataController(SeasonalProduceContext context)
        {
            this.context = context;
        }
        
        public IQueryable<FoodDataDto> Get()
        {
            return context.FoodDataItems.Include(x => x.Category)
                .AsQueryable()
                .ProjectTo<FoodDataDto>();
        }
        
        public SingleResult<FoodDataDto> Get([FromODataUri] int key)
        {
            return SingleResult.Create<FoodDataDto>( context.FoodDataItems
                .Where(x => x.Id == key).ProjectTo<FoodDataDto>());
        }
    }
}