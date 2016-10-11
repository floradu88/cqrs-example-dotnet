using CQRS.Example.Domain.PubSub;
using NUnit.Framework;

namespace CQRS.Example.Tests.Unit
{
    [TestFixture]
    public class PublisherTests
    {
        [Test]
        public void should_be_able_to_create_a_publisher()
        {
            var publisher = new Publisher<object>();

            Assert.That(publisher, Is.Not.Null);
        }

        [Test]
        public void should_be_able_to_push_a_message()
        {
            var publisher = new Publisher<object>();

            publisher.PushMessage(new CustomEventArgs<object>()
            {
                Message = "some message",
                Argument = new object()
            });
        }
    }
}
