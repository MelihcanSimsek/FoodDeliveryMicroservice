using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Meals.Queries.GetAllMeal
{
    public class GetAllMealQueryResponse
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public Guid RestaurantId { get; set; } 
        public Guid BranchId { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; } 
        public Decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int? Portion { get; set; }
        public int Gram { get; set; }
    }
}
