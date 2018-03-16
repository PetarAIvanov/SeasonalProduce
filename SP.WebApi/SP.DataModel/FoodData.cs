using System;
using System.Collections.Generic;
using System.Text;

namespace SP.DataModel
{
    public class FoodData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; } 
        public FoodCategory Category { get; set; }

        public int InSeasonFromMonth { get; set; }
        public int InSeasonToMonth { get; set; }

        public string ImageUrl { get; set; }
    }
}
