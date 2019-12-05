using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson04_QuickSort_and_Trees.Ex2FirstChildNextSibling
{
    public interface IFCNSNode<T>
    {
        T GetData();
        FCNSNode<T> GetFirstChild();
        FCNSNode<T> GetNextSibling();
    }
}
