using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Services
{
    public class JobServices
    {
        private readonly Guid _UserId;
        public JobServices(Guid userid)
        {
            _UserId = userid;
        }
        
    }
}
