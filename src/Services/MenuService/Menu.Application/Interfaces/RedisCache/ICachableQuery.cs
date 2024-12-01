using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Interfaces.RedisCache
{
    public interface ICachableQuery
    {
        public string CacheKey { get; }
        public double CacheTime { get; }
    }
}
