using Menu.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Domain.Entities
{
    public class Liquid : EntityBase
    {
        public int Milliliter { get; set; }

        public Liquid()
        {
            
        }

        public Liquid(int milliliter)
        {
            Milliliter = milliliter;
        }
    }
}
