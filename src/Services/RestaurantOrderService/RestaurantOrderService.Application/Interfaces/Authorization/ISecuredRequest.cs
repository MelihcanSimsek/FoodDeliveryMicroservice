﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderService.Application.Interfaces.Authorization
{
    public interface ISecuredRequest
    {
        public string[] Roles { get; }
    }
}
