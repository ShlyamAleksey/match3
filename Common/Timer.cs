using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lizzard.ComponentPattern;

namespace Lizzard.Common
{
    public class Timer : EventDispatcher
    {
        public int currentCount = 1;
        private double currentTime = 0;
        public long totalCount;
        public float delay;
        public double startTime;

        private long totalTime;

        public Timer(float delay, int count)
        {
            this.delay = delay;
            this.totalCount = count;
            totalTime = (long)delay * totalCount;
        }

        private void onUpdate(Event e)
        {
            currentTime = Stage.currentTimeMS - startTime;
            if (currentCount * delay < currentTime)
            {
                currentCount++;
                dispatchEvent(new Event(TimerEvent.TIMER));
            }

            if (currentTime >= totalTime)
            {
                stop();
                dispatchEvent(new Event(TimerEvent.TIMER_COMPLETE));
            }
        }

        public Timer(float delay)
        {
            this.delay = delay;
            this.totalCount = int.MaxValue;
            totalTime = (long)delay * totalCount;
        }

        public void start()
        {
            startTime = Stage.currentTimeMS;
            currentCount = 1;
            currentTime = 0;
            Stage.instance.addEventListener(Stage.UPDATE, onUpdate);
        }

        public void stop()
        {
            Stage.instance.removeEventListener(Stage.UPDATE, onUpdate);
        }
    }
}
