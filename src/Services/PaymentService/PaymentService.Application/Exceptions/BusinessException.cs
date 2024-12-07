using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {

        }
        public BusinessException(string message) : base(message)
        {

        }
    }
}
