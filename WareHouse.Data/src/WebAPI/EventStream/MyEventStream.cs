using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.EventStream
{
    public class MyEventStream // TODO: Это общая логика приложения, этот класс не должен находится в сборке webapi.
    {
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
                if (sender == null) // TODO: Не потокобезопасно
                    sender = new MyEventStream();

                return sender;
            }
        }

        public void Add<T>(IObservable<T> observeble)
        {
            observebles.Add(new KeyValue(typeof(T).Name, observeble));

            List<IObserver<T>> list = subscribers
                .Where(x => x.Key == typeof(T).Name)
                .Select(x => x.Value as IObserver<T>)
                .ToList();

            if (list.Count == 0)
                return;

            list.ForEach(item => observeble.Subscribe(item));
        }

        public void Subscribe<T>(IObserver<T> observer)
        {
            subscribers.Add(new KeyValue(typeof(T).Name, observer));

            List<IObservable<T>> list = observebles
                .Where(x => x.Key == typeof(T).Name)
                .Select(x => x.Value as IObservable<T>)
                .ToList();

            if (list.Count == 0) // TODO: В асинхронном приложении нельзя гарантировать порядок выполения кода, если наблюдаемый объект зарегистрируется позже, то этот наблюдатель на него не подпишится.
                return;

            list.ForEach(item => item.Subscribe(observer));
        }
    }
}
