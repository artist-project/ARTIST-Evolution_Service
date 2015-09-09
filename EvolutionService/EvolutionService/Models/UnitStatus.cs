using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionService.Models
{
    public enum UnitStatus
    {
        NotStarted = 0,
        FailedOnStart = 1,
        InProgress = 2,
        ErrorOccurred = 3,
        Completed = 4
    }
}
