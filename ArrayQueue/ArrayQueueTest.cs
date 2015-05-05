using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ArrayQueue
{
    public class ArrayQueueTest
    {
        [Test]
        public void Enqueue()
        {
            ArrayQueue<int> queue = new ArrayQueue<int>();
            queue.Enqueue(5);
            Assert.IsTrue(queue.NumberOfItemsInQueue == 1);
        }

        [Test]
        public void Dequeue()
        {
            ArrayQueue<int> queue = new ArrayQueue<int>();
            queue.Enqueue(5);
            int value = queue.Dequeue();
            Assert.IsTrue(value == 5);
        }

        [Test]
        public void CorrectOrder()
        {
            ArrayQueue<int> queue = new ArrayQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);

            int value = queue.Dequeue();
            Assert.IsTrue(value == 5);
            value = queue.Dequeue();
            Assert.IsTrue(value == 6);
            value = queue.Dequeue();
            Assert.IsTrue(value == 7);
            value = queue.Dequeue();
            Assert.IsTrue(value == 8);
        }

        public void ResizeQueue()
        {
            ArrayQueue<int> queue = new ArrayQueue<int>();
            Assert.IsTrue(queue.QueueSize == 1);

            int queueSize = queue.QueueSize;
            queue.Enqueue(1);
            Assert.IsTrue(queue.QueueSize == 2);

            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Assert.IsTrue(queue.QueueSize == 8);
            queue.Dequeue();
            Assert.IsTrue(queue.QueueSize == 8);
            queue.Dequeue();
            Assert.IsTrue(queue.QueueSize == 4);
        }
    }
}
