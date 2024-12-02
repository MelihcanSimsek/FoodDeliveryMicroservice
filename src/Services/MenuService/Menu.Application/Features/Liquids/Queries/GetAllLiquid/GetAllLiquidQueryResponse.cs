using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Liquids.Queries.GetAllLiquid
{
    public class GetAllLiquidQueryResponse
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
        public int Milliliter { get; set; }
    }
}
