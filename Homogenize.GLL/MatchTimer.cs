using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Homogenize.GLL
{
    public class MatchTimer
    {
        private DateTime startTime;
        private DateTime endTime;

        public TimeSpan CurrentTimeSpan
        {
            get 
            {
                if (DateTime.Now - startTime > MaxMatchTimeSpan)
                {
                    Stop();
                    endTime = startTime.Add(MaxMatchTimeSpan);
                    IsTimerAlive = false;
                    return MaxMatchTimeSpan;
                }
                else if (IsTimerAlive)
                {
                    return DateTime.Now - startTime;
                }
                else
                {
                    return endTime - startTime;
                }
            }
        }
        public bool IsTimerAlive { get; private set; }
        public TimeSpan MaxMatchTimeSpan { get; set; }

        public MatchTimer()
        {
            MaxMatchTimeSpan = TimeSpan.MaxValue;
        }

        public void Start()
        {
            IsTimerAlive = true;
            startTime = DateTime.Now;
        }
        public void Stop()
        {
            IsTimerAlive = false;
            endTime = DateTime.Now;
        }
    }
}
