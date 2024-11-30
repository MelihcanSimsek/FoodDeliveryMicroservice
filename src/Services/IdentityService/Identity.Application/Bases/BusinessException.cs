using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Bases
{
    public class BusinessException:Exception
    {
        public BusinessException(string message) : base(message)
        {
            
        }
    }
}
