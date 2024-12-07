using PaymentService.Application.Exceptions;
using PaymentService.Application.Features.Accounts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Exceptions
{
    public class AccountAlreadyExistsException : BusinessException
    {
        public AccountAlreadyExistsException() : base(Messages.AccountAlreadyExists)
        {
            
        }
    }
}
