using CQRS.Example.Domain.Interfaces;
using NLog;
using System;

namespace CQRS.Example.Domain.PubSub
{
    public class Subscriber<T> : ISubscriber<T> where T : class
    {
        private readonly string _id;
        private readonly ILogger _logger;

        public Subscriber(string id, IPublisher<T> pub, ILogger logger)
        {
            if (pub == null) throw new ArgumentNullException(nameof(pub));
            if (logger == null) throw new ArgumentNullException(nameof(logger));
            _id = id;
            _logger = logger;

            pub.RaiseCustomEvent += HandleCustomEvent;
        }

        // Define what actions to take when the event is raised.
        void HandleCustomEvent(object sender, CustomEventArgs<T> e)
        {
            _logger.Info(_id + " received this message: {0}", e.Message);
        }
    }
}