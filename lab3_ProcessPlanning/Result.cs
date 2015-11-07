using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessesPlanning
{
    class Result
    {
        public int ProcessId { get; set; }
        public int ProcessPriority { get; set; }
        public long EndTime { get; set; }
        public long PauseTime { get; set; }
    }
}
