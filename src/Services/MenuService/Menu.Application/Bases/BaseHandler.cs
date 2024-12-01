using Menu.Application.Interfaces.CustomMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Bases
{
    public class BaseHandler
    {
        public readonly IHttpContextAccessor httpContextAccessor;
        public readonly IMapper mapper;

        public BaseHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
        }
    }
}
