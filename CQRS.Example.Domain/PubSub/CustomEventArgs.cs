namespace CQRS.Example.Domain.PubSub
{
    public class CustomEventArgs<T> where T : class
    {
        public string Message { get; set; }

        public T Argument { get; set; }
    }
}