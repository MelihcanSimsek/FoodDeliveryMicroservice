using Microsoft.AspNetCore.Http;
using OrderService.Application.Interfaces.CustomMapper;
using OrderService.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Bases
{
    public class BaseHandler
    {
        public readonly IUnitOfWork unitOfWork;
        public readonly IMapper mapper;
        public readonly IHttpContextAccessor httpContextAccessor;

        public BaseHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }
    }
}
