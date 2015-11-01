using System.Diagnostics;
using System.Threading;

namespace ProcessesPlanning
{
    public class Process
    {
        public int Id { get; set; }
        public long ArrivalTime { get; set; }
        public int ExecutionTime { get; set; }
        public int Priority { get; set; }
        private long pauseTime;
        private Stopwatch watch;

        public Process()
        {
            Id = 0;
            ArrivalTime = 0;
            ExecutionTime = 0;
            pauseTime = 0;
            watch = Stopwatch.StartNew();
        }

        public Process(int id, long arrivalTime, int executionTime, int priority)
        {
            Id = id;
            ArrivalTime = arrivalTime;
            ExecutionTime = executionTime;
            pauseTime = 0;
            Priority = priority;
            watch = Stopwatch.StartNew();
        }

        public void Execute()
        {
            watch.Stop();
            pauseTime = watch.ElapsedMilliseconds;
            Thread.Sleep(this.ExecutionTime);
        }

        public long GetPauseTime()
        {
            return pauseTime;
        }
    }
}
