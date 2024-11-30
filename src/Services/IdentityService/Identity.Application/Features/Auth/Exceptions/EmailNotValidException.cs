using Identity.Application.Bases;
using Identity.Application.Exceptions;
using Identity.Application.Features.Auth.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Exceptions
{
    public class EmailNotValidException : BusinessException
    {
        public EmailNotValidException() :base(Messages.EmailNotValid)
        {
            
        }
    }
}
