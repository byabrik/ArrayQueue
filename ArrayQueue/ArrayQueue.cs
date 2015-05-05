using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            Queue[Head] = value;
            Head--;
            if (Head < 0)
            {
                if (Tail - Head > Queue.Length / ResizeCoefficient)
                    ResizeQueue(ResizeCoefficient*Queue.Length);
                else
                    RestartQueue();
            }
        }

        public T Dequeue()
        {
            T value = Queue[Tail];
            Queue[Tail] = default(T);
            if (Tail <= Head)
                return value;
            Tail--;
            if (NumberOfItemsInQueue < Queue.Length / (ResizeCoefficient * 2))
                ResizeQueue(Queue.Length/ResizeCoefficient);
            return value;
        }

        public int QueueSize {
            get { return Queue.Length; }
        }

        public int NumberOfItemsInQueue
        {
            get { return Tail - Head; }
        }

        private void RestartQueue()
        {
            int newHead = Math.Max(Head, 0);
            for (int i = Tail, j = Queue.Length - 1; i >= newHead; i--, j--)
            {
                Queue[j] = Queue[i];
            }
            Tail = Queue.Length - 1;
            Head = Tail - Head;
        }

        private void ResizeQueue(int newLength)
        {
            if (newLength <= 0)
                return;

            T[] newQueue = new T[newLength];
            int numberOfItems = NumberOfItemsInQueue;
            int newHead = Math.Max(Head, 0);
            for (int i = Tail, j = newLength - 1; i >= newHead; i--, j--)
            {
                newQueue[j] = Queue[i];
            }
            Tail = newLength - 1;
            Head = newLength - numberOfItems -1;
            Queue = newQueue;
        }

        private T[] Queue;
        private int Head;
        private int Tail;
        private const int ResizeCoefficient = 100;
        private const int StartCapacity = 1;
    }
}
