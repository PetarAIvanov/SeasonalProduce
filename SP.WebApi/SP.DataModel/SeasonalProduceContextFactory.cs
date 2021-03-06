﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SP.DataModel
{
    class SeasonalProduceContextFactory: IDesignTimeDbContextFactory<SeasonalProduceContext>
    {
        public SeasonalProduceContext CreateDbContext(string[] options)
        {
            var builder = new DbContextOptionsBuilder<SeasonalProduceContext>();
            builder.UseSqlServer(
                 @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Dev\SeasonalProduce\SP.WebApi\SEASONAL_PRODUCE_DB.mdf;Integrated Security=True;Connect Timeout=30");

            return new SeasonalProduceContext(builder.Options);
        }
    }
}
