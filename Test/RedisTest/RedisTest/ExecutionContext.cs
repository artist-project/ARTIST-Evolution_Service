using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTest
{
    public class ExecutionContext
    {
        public string ExecutionID { get; set; }

        public List<string> Artefacts { get; set; }

        public ExecutionContextStatus Status { get; set; }

        public int CurrentState { get; set; }

        public string Strategy { get; set; }

        public string Timestamp { get; set; }
    }

    public enum ExecutionContextStatus
    {
        NotStarted = 0,
        FailedOnStart = 1,
        InProgress = 2,
        ErrorOccurred = 3,
        StoppedByUser = 4,
        Completed = 5
    }
}
