using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson02_Basic_Data_Structures.Ex3Stack
{
    public interface IMyStack<T>
    {
        bool IsEmpty();
        void Push(T data);
        T Top();
        T Pop();
    }

    public class MyStackEmptyException : Exception
    {
    }
}
