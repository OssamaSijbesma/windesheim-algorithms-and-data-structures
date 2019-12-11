using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT1.Ex1Scheduler
{
    public enum Priority
    {
        High = 0,
        Medium = 1,
        Low = 2
    }

    interface IScheduler<T>
    {
        void Enqueue(Priority priority, T Data);
        T Dequeue();
    }
}
