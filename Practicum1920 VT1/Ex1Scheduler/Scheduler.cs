using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum1920_VT1.Ex1Scheduler
{
    public class Scheduler<T> : IScheduler<T>
    {
        // Insert data members here
        private MyQueue<T>[] schedule;

        public Scheduler()
        {
            schedule = new MyQueue<T>[3];
            schedule[0] = new MyQueue<T>();
            schedule[1] = new MyQueue<T>();
            schedule[2] = new MyQueue<T>();

        }

        public void Enqueue(Priority priority, T Data)
        {
            schedule[(int)priority].Enqueue(Data);
        }

        public T Dequeue()
        {
            T item = default;

            if (!schedule[0].IsEmpty())
                item = schedule[0].Dequeue();
            else if (!schedule[1].IsEmpty())
                item = schedule[1].Dequeue();
            else if (!schedule[2].IsEmpty())
                item = schedule[2].Dequeue();

            if (!schedule[1].IsEmpty())
                schedule[0].Enqueue(schedule[1].Dequeue());

            if (!schedule[2].IsEmpty())
                schedule[1].Enqueue(schedule[2].Dequeue());

            return item;
        }

        override public string ToString()
        {
            StringBuilder[] items = new StringBuilder[3];
            items[0] = new StringBuilder();
            items[1] = new StringBuilder();
            items[2] = new StringBuilder();

            foreach (int priority in Enum.GetValues(typeof(Priority)))
                for (int i = 0; i < schedule[priority].queue.Count; i++)
                    if (i == 0)
                        items[priority].Append($"{schedule[priority].queue[i]}");
                    else
                        items[priority].Append($",{schedule[priority].queue[i]}");

            return "{High:[" + items[0].ToString() + "],Medium:[" + items[1].ToString() + "],Low:[" + items[2].ToString() + "]}";
        }
    }
}
