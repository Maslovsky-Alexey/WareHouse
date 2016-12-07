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
        private readonly List<KeyValue> observebles;
        private readonly List<KeyValue> subscribers;

        private MyEventStream()
        {
            observebles = new List<KeyValue>();
            subscribers = new List<KeyValue>();
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

        public void Add<T>(IObservable<T> observeble) where T : new ()
        {
            observebles.Add(new KeyValue(typeof(T).FullName, observeble));

            List<IObserver<T>> list = subscribers
                .Where(x => GetModelTypeFromObserver(x.Value).GetType().GetTypeInfo().IsInstanceOfType(new T()))
                .Select(x => x.Value as IObserver<T>)
                .ToList();

            if (list.Count == 0)
                return;
        }

        public void Subscribe<T>(IObserver<T> observer) where T : new()
        {
            subscribers.Add(new KeyValue(typeof(T).FullName, observer));

            List<IObservable<T>> list = observebles
                .Where(x => new T().GetType().GetTypeInfo().IsInstanceOfType(Activator.CreateInstance(GetModelTypeFromObserver(observer))))
                .Select(x => x.Value as IObservable<T>)
                .ToList();
          
            if (list.Count == 0)
                return;
        }

        public void Emit<T>(T value) where T : new()
        {
            List<IObserver<T>> list = subscribers
                .Where(x => GetModelTypeFromObserver(x.Value).GetTypeInfo().IsInstanceOfType(value))
                .Select(x => x.Value as IObserver<T>)
                .ToList();

            if (list.Count == 0)
                return;

            list.ForEach(item => item.OnNext(value));
        }

        private Type GetModelTypeFromObserver(object observer)
        {
            return observer
                .GetType()
                .GetTypeInfo()
                .GetInterfaces()
                .FirstOrDefault(x => x.Name.IndexOf("IObserver") > -1)
                .GenericTypeArguments[0];
        }
    }
}
