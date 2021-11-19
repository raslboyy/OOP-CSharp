using Banks.Entities.ClientModule;
using Banks.Entities.ClientModule.ClientBuilderModule;
using Banks.Tools;
using NUnit.Framework;

namespace Banks.Tests
{
    public class ClientBuilderTest
    {
        [Test]
        public void GetResult_AllFields_IsGoodTrue()
        {
            var builder = new LastClientBuilder();

            Client client = builder.SetFirstName("FirstName")
                .SetLastName("LastName")
                .SetAddress("Address")
                .SetPassport("Passport")
                .GetResult();

            Assert.AreEqual(true, client.IsGood);
        }

        [Test]
        public void GetResult_NotAllFields_IsGoodFalse()
        {
            var builder = new LastClientBuilder();

            Client client = builder.SetFirstName("FirstName")
                .SetLastName("LastName")
                .SetAddress("Address")
                .GetResult();

            Assert.AreEqual(false, client.IsGood);
        }

        [Test]
        public void GetResult_FirstNameIsNotFilled_ThrowException()
        {
            var builder = new LastClientBuilder();
            
            builder = builder.SetLastName("LastName")
                .SetAddress("Address");
            
            Assert.Catch<ClientBuilderException>(() =>
            {
                builder.GetResult();
            });
        }
    }
}