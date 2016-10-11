using System.Collections.Generic;
using System.Linq;

namespace CQRS.Example.Domain.Queue
{
    public class MessageQueue<T> where T : class
    {
        private readonly List<Message<T>> _queue;

        private readonly object _lock = new object();

        public MessageQueue()
        {
            this._queue = new List<Message<T>>();
        }

        public void Push(Message<T> message)
        {
            lock (_lock)
            {
                _queue.Add(message);
            }
        }

        public Message<T> Pop(string topic)
        {
            lock (_lock)
            {
                Message<T> firstMessage = _queue.FirstOrDefault(x => x.Topic == topic);

                if (firstMessage != null)
                {
                    _queue.Remove(firstMessage);
                }

                return firstMessage;
            }
        }

        public List<string> AvailableTopics()
        {
            lock (_lock)
            {
                return _queue.Select(x => x.Topic).Distinct().ToList();
            }
        }
    }
}
