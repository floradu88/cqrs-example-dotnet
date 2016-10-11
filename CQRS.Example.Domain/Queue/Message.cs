using System;

namespace CQRS.Example.Domain.Queue
{
    public class Message<T> where T : class
    {
        public string Topic { get; }
        public T Parameter { get; }

        public Message(string topic, T parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            Topic = topic;
            Parameter = parameter;
        }
    }
}