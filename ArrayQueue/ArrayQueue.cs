using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayQueue
{
    public class ArrayQueue<T>
    {
        public ArrayQueue()
        {
            Queue = new T[StartCapacity];
            Head = Tail = StartCapacity - 1;
        }

        public void Enqueue(T value)
        {

        }

        public T Dequeue()
        {
            return default(T);
        }

        private class Node<TNode> 
        {
            public TNode Value { get; set; }
            public Node<TNode> Next { get; set; }
        }

        private T[] Queue;
        private int Head;
        private int Tail;
        private const int StartCapacity = 10;
    }
}
