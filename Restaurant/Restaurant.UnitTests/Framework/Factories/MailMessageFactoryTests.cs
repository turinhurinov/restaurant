using FluentAssertions;
using NUnit.Framework;
using Restaurant.Framework.Factories;

namespace Restaurant.UnitTests.Framework.Factories
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class MailMessageFactoryTests
    {
        #region members - setup

        MailMessageFactory? factory;

        [SetUp]
        public void Initialize()
        {
            factory = new MailMessageFactory();
        }

        #endregion

        [Test]
        public void CreateMailMessage_SingleRecipient_ReturnMailMessageWithRecipientsInToField()
        {
            //Arrange
            string senderEmailAddress = "sender@example.org";
            string senderName = "bar sender";
            string subject = "foo subject";
            string recipientAddresses = "test@example.org";
            bool isHtmlContent = true;
            string mailBody = "foo body";

            //Act
            var result = factory!.CreateMailMessage(senderEmailAddress, senderName, subject, recipientAddresses, isHtmlContent, mailBody);

            //Assert
            result.Subject.Should().Be(subject);
            result.Body.Should().Be(mailBody);
            result.IsBodyHtml.Should().Be(isHtmlContent);
            result.To.Should().HaveCount(1);
            result.To[0].Should().Be(recipientAddresses);
        }
    }
}