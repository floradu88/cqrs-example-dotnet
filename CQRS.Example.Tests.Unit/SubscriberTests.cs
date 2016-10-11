using CQRS.Example.Domain.PubSub;
using Moq;
using NLog;
using NUnit.Framework;
using System;

namespace CQRS.Example.Tests.Unit
{
    [TestFixture]
    public class SubscriberTests
    {
        [Test]
        public void should_be_able_to_create_a_subscriber()
        {
            var pub = new Publisher<object>();
            var mockLogger = new Mock<ILogger>();
            var subscriber = new Subscriber<object>("sub1", pub, mockLogger.Object);

            Assert.That(subscriber, Is.Not.Null);
        }

        [Test]
        public void should_throw_an_exception_when_publisher_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new Subscriber<object>("sub1", null, null));
        }

        [Test]
        public void should_throw_an_exception_when_logger_is_null()
        {
            var pub = new Publisher<object>();
            Assert.Throws<ArgumentNullException>(() => new Subscriber<object>("sub1", pub, null));
        }

        [Test]
        public void should_be_able_to_create_a_subscriber_and_publish_a_message()
        {
            var someMessage = "someMessage";
            var pub = new Publisher<object>();
            var mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Info(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            var subscriber = new Subscriber<object>("sub1", pub, mockLogger.Object);

            pub.Raise(new object(), new CustomEventArgs<object>()
            {
                Argument = null,
                Message = someMessage
            });

            mockLogger.Verify(x => x.Info(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
