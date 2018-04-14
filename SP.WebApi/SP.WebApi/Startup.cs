using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SP.DataModel;
using SP.WebApi.DTO;

namespace SP.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOData();
            string conString = ConfigurationExtensions
                   .GetConnectionString(this.Configuration, "produceDb");
            services.AddDbContext<SeasonalProduceContext>(options => options.UseSqlServer(conString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeasonalProduceContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            //if (context.Database.IsInMemory())
            //{
            //    SeedData(context);
            //}

            RegisterAutomapper();

            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<FoodDataDto>(nameof(FoodData));

            app.UseMvc(routebuilder =>
            {
                routebuilder.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
                routebuilder.MapODataServiceRoute("odata", null, builder.GetEdmModel());
                routebuilder.EnableDependencyInjection();
            });
        }

        private void RegisterAutomapper()
        {
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<FoodData, FoodDataDto>()
                .ForMember(x=> x.Category, opt=> opt.MapFrom(x=> x.Category.Name));
            });
        }

        //private void SeedData(SeasonalProduceContext context)
        //{
        //    var fruitcat = new FoodCategory() { Name = "Fruits" };
        //    var veggiecat = new FoodCategory() {Name = "Vegetables" };
        //    context.Add(fruitcat);
        //    context.Add(veggiecat);

        //    var foodItems = new List<FoodData>()
        //    {
        //        new FoodData() { CategoryId = fruitcat.Id, Name= "Apples", InSeasonFromMonth = 1, InSeasonToMonth=12},
        //        new FoodData() { CategoryId = veggiecat.Id, Name = "Potatoes", InSeasonFromMonth = 1, InSeasonToMonth = 12}
        //    };

        //    context.AddRange(foodItems);
        //    context.SaveChanges();
        //}
    }
}
