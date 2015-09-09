using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExecutionContext c = new ExecutionContext() { ExecutionID = "123456789", Artefacts = new List<string>() { "file1.xmi", "file2.xmi" }, Status = ExecutionContextStatus.ErrorOccurred, CurrentState = 0, Strategy = "Default", Timestamp = DateTime.UtcNow.ToString() };

            //using (var redisClient = new RedisClient())
            //{
            //    redisClient.Set(c.ExecutionID, c);
            //}
            
            ServiceStack.Redis.RedisClient client = new ServiceStack.Redis.RedisClient("192.168.132.136");

            MessagingService service = new MessagingService();
            long s = service.Publish("ProcessManager", "5f96c74e-1c2c-48eb-95e4-aa8530dd6f4a");
            Console.WriteLine(s);
            //service.OnMessage = (channel, msg) => { Console.WriteLine(msg); };
            //service.Subscribe("test");
            
            Console.ReadLine();
        }
    }
}
