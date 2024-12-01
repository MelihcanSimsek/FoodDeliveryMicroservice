using Menu.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Domain.Entities
{
    public class Meal : EntityBase
    {
        public int? Portion { get; set; }
        public int Gram { get; set; }
        public Meal()
        {
            
        }
        public Meal(int? portion, int gram)
        {
            Portion = portion;
            Gram = gram;
        }
    }
}
