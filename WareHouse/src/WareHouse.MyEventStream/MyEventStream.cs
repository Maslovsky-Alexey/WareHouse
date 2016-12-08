using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WareHouse.MyEventStream
{
    public class MyEventStream
    {
        private static object threadlock = new object();

        private static MyEventStream sender;

        private readonly List<WeakReference> subscribers;

        private MyEventStream()
        {
            subscribers = new List<WeakReference>();
        }

        public static MyEventStream Instance
        {
            get
            {
                lock (threadlock)
                {
                    if (sender == null)
                        sender = new MyEventStream();

                    return sender;
                }
            }
        }

        public void Subscribe<T>(IObserver<T> observer)
        {
            subscribers.Add(new WeakReference(observer));
        }

        public void Emit<T>(T value)
        {
            RemoveNullObservers();

            subscribers
                .Where(x => GetModelTypeFromObserver(x.Target).IsInstanceOfType(value))
                .Select(x => x.Target as IObserver<T>)
                .ToList()
                .ForEach(item => item.OnNext(value));
        }


        private void RemoveNullObservers()
        {
            subscribers.RemoveAll((obj) => !obj.IsAlive);
        }

        private Type GetModelTypeFromObserver(object observer)
        {
            return observer
                .GetInterfaceByPattern("IObserver", false)
                .GenericTypeArguments[0];
        }
    }
}
