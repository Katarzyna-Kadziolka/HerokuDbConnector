using System;
using FluentAssertions;
using Npgsql;
using NUnit.Framework;

namespace HerokuDbConnector.Tests.Unit;

public class HerokuDbConnectorTests {
    [SetUp]
    public void Setup() {
        Environment.SetEnvironmentVariable("DATABASE_URL", TestData.GetDbUrl());
    }

    [Test]
    public void Build_DefaultOptions_ShouldReturnConnectionStringWithDefaultValues() {
        // Arrange
        var herokuDbConnector = new HerokuDbConnector();
        // Act
        var connectionString = herokuDbConnector.Build();
        // Assert
        var npgsqlConnectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);
        npgsqlConnectionStringBuilder.Host.Should().Be(TestData.Host);
        npgsqlConnectionStringBuilder.Port.Should().Be(TestData.Port);
        npgsqlConnectionStringBuilder.Username.Should().Be(TestData.Username);
        npgsqlConnectionStringBuilder.Password.Should().Be(TestData.Password);
        npgsqlConnectionStringBuilder.Database.Should().Be(TestData.Database);
        npgsqlConnectionStringBuilder.SslMode.Should().Be(SslMode.Require);
        npgsqlConnectionStringBuilder.TrustServerCertificate.Should().BeTrue();
    }
    [Test]
    public void Build_DatabaseUrl_ShouldReturnConnectionStringWithGivenUrlValues() {
        // Arrange
        var databaseUrl = TestData.GetDbUrl();
        var herokuDbConnector = new HerokuDbConnector(o => o.DatabaseUrl = databaseUrl);
        // Act
        var connectionString = herokuDbConnector.Build();
        // Assert
        var npgsqlConnectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);
        npgsqlConnectionStringBuilder.Host.Should().Be(TestData.Host);
        npgsqlConnectionStringBuilder.Port.Should().Be(TestData.Port);
        npgsqlConnectionStringBuilder.Username.Should().Be(TestData.Username);
        npgsqlConnectionStringBuilder.Password.Should().Be(TestData.Password);
        npgsqlConnectionStringBuilder.Database.Should().Be(TestData.Database);
    }
    [Test]
    [TestCase(SslMode.Disable)]
    [TestCase(SslMode.Allow)]
    [TestCase(SslMode.Prefer)]
    [TestCase(SslMode.Require)]
    [TestCase(SslMode.VerifyFull)]
    [TestCase(SslMode.VerifyCA)]
    public void Build_SslMode_ShouldReturnConnectionStringWithGivenSslMode(SslMode mode) {
        // Arrange
        var herokuDbConnector = new HerokuDbConnector(o => o.SslMode = mode);
        // Act
        var connectionString = herokuDbConnector.Build();
        // Assert
        var npgsqlConnectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);
        npgsqlConnectionStringBuilder.SslMode.Should().Be(mode);
    }
    [Test]
    public void Build_TrustServerCertificate_ShouldReturnConnectionStringWithGivenTrustServerCertificate() {
        // Arrange
        var herokuDbConnector = new HerokuDbConnector(o => o.TrustServerCertificate = false);
        // Act
        var connectionString = herokuDbConnector.Build();
        // Assert
        var npgsqlConnectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);
        npgsqlConnectionStringBuilder.TrustServerCertificate.Should().BeFalse();
    }
    [Test]
    public void Build_NullDatabaseUrl_ShouldThrowNullReferenceException() {
        // Arrange
        Environment.SetEnvironmentVariable("DATABASE_URL", "");
        var herokuDbConnector = new HerokuDbConnector();
        // Act
        Action act = () => herokuDbConnector.Build();
        // Assert
        act.Should().Throw<NullReferenceException>().WithMessage("Database url was null or empty. Provide a valid database url or use default");
    }
}