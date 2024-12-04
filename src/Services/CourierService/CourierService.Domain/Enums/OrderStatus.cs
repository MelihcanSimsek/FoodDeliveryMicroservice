using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Domain.Enums
{
    public enum OrderStatus
    {
        PENDING,
        DELIVERY_STARTED,
        ORDER_COMPLETED,
        DELIVERY_FAILED
    }
}
