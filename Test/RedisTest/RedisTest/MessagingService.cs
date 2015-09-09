using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTest
{
    public class MessagingService : IMessagingService
    {
        private string _host;

        public MessagingService()
        {
            _host = "192.168.132.136";
        }

        public Action<string> OnSubscribe { get; set; }
        public Action<string, string> OnMessage { get; set; }
        public Action<string> OnUnSubscribe { get; set; }

        public void Subscribe(params string[] channels)
        {
            using (var redisConsumer = new RedisClient(_host))
            using (var subscription = redisConsumer.CreateSubscription())
            {
                subscription.OnSubscribe = OnSubscribe;
                subscription.OnUnSubscribe = OnUnSubscribe;
                subscription.OnMessage = OnMessage;

                subscription.SubscribeToChannels(channels); //blocking
            }
        }

        public long Publish(string toChannel, string msg)
        {
            using (var redisPublisher = new RedisClient(_host))
            {
                return redisPublisher.PublishMessage(toChannel, msg);
            }
        }
    }
}
