using NUnit.Framework;

namespace HerokuDbConnector.UnitTests {
    [TestFixture]
    public class HerokuDbConnectorTests {
        [Test]
        public void Build_DatabaseUrl_ShouldReturnString() {
            // Arrange
            var databaseUrl =
                "UserID=postgres;Password=TestPassword;Host=localhost;Port=5432;Database=TestDatabase;Pooling=true;MinPoolSize=0;MaxPoolSize=100;ConnectionLifetime=0;";
            var herokuDbConnector = new 
            // Act

            // Assert
        }
    }
}