using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Features.Accounts.Queries.GetUserAccount
{
    public class GetUserAccountQueryResponse
    {
        public decimal Balance { get; set; } 
        public DateTime? LastUpdateDate { get; set; }
    }
}
