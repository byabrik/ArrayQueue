using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArrayQueue
{
    public class ArrayQueue<T> where T: class
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

        private void RestartQueue()
        {
            throw new NotImplementedException();
        }

        private void ResizeQueue(int i)
        {
            throw new NotImplementedException();
        }

        public T Dequeue()
        {
            if (Queue[Tail] == null)
                return null;

            T value = Queue[Tail];
            Queue[Tail] = null;
            Tail--;
            if (Tail - Head < Queue.Length / (ResizeCoefficient * 2))
                ResizeQueue(Queue.Length / ResizeCoefficient);
            return value;
        }

        Type GetNullableType(Type type)
        {
            // Use Nullable.GetUnderlyingType() to remove the Nullable<T> wrapper if type is already nullable.
            type = Nullable.GetUnderlyingType(type);
            if (type.IsValueType)
                return typeof(Nullable<>).MakeGenericType(type);
            else
                return type;
        }

        private T[] Queue;
        private int Head;
        private int Tail;
        private readonly int ResizeCoefficient = 2;
        private const int StartCapacity = 10;
    }
}
