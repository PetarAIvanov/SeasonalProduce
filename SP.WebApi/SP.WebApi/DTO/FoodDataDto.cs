using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.WebApi.DTO
{
    public class FoodDataDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int InSeasonFromMonth { get; set; }
        public int InSeasonToMonth { get; set; }

        public string ImageUrl { get; set; }
    }
}
