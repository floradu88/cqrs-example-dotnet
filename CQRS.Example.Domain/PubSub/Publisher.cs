using CQRS.Example.Domain.Interfaces;
using System;

namespace CQRS.Example.Domain.PubSub
{
    public class Publisher<T> : IPublisher<T> where T : class
    {
        public event Action<object, CustomEventArgs<T>> RaiseCustomEvent;

        public void PushMessage(CustomEventArgs<T> message)
        {
            RaiseCustomEvent += Raise;
        }

        public virtual void Raise(object sender, CustomEventArgs<T> e)
        {
            if (RaiseCustomEvent != null)
            {
                e.Message = nameof(sender);

                //raise event
                RaiseCustomEvent(this, e);
            }
        }
    }
}
