using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SP.DataModel;

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

            //var connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Projects\localdbs\SeasonalProduce.mdf;Integrated Security=True;Connect Timeout=30";
            services.AddDbContext<SeasonalProduceContext>(options => options.UseInMemoryDatabase("SeasonalProduceDb"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeasonalProduceContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            if (context.Database.IsInMemory())
            {
                SeedData(context);
            }

            app.UseMvc();
        }

        private void SeedData(SeasonalProduceContext context)
        {
            var fruitcat = new FoodCategory() { Id = 1, Name = "Fruits" };
            var veggiecat = new FoodCategory() { Id = 2, Name = "Vegetables" };
            context.Add(fruitcat);
            context.Add(veggiecat);

            var foodItems = new List<FoodData>()
            {
                new FoodData() { CategoryId = fruitcat.Id, Name= "Apples", InSeasonFromMonth = 1, InSeasonToMonth=12},
                new FoodData() { CategoryId = veggiecat.Id, Name = "Potatoes", InSeasonFromMonth = 1, InSeasonToMonth = 12}
            };

            context.AddRange(foodItems);
            context.SaveChanges();
        }
    }
}
