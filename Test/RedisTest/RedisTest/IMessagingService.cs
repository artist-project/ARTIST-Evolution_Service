using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTest
{
    public interface IMessagingService
    {
        void Subscribe(params string[] channels);
        long Publish(string toChannel, string msg);
    }
}
