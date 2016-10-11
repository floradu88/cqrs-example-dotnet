using CQRS.Example.Domain.PubSub;
using System;

namespace CQRS.Example.Domain.Interfaces
{
    public interface IPublisher<T> where T : class
    {
        void PushMessage(CustomEventArgs<T> parameter);
        void Raise(object sender, CustomEventArgs<T> e);

        event Action<object, CustomEventArgs<T>> RaiseCustomEvent;
    }
}
