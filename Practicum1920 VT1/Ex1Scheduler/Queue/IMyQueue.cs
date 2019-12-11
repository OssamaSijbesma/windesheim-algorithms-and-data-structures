using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT1.Ex1Scheduler
{
    public interface IMyQueue<T>
    {
        bool IsEmpty();
        void Enqueue(T data);
        T GetFront();
        T Dequeue();
        void Clear();
    }

    public class MyQueueEmptyException : Exception
    {
    }
}
