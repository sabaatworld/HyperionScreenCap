using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HyperionScreenCap
{
    /// <summary>
    /// A thread safe queue that automatically dequeues old objects. If the object being is of type IDisposable,
    /// it is automatically disposed while dequeuing.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class FixedSizeConcurrentQueue<T> : ConcurrentQueue<T>
    {
        private readonly object syncObject = new object();

        public int Size { get; private set; }
        private bool _autoDispose;

        public FixedSizeConcurrentQueue(int size) : base()
        {
            Size = size;
        }

        public new void Enqueue(T obj)
        {
            base.Enqueue(obj);
            lock ( syncObject )
            {
                while ( base.Count > Size )
                {
                    T outObj;
                    bool dequeueSuccess = base.TryDequeue(out outObj);
                    if ( dequeueSuccess && outObj is IDisposable )
                        ((IDisposable) outObj).Dispose();
                }
            }
        }

    }
}
