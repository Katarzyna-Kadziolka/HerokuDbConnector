using System;
using FluentAssertions;
using Npgsql;
using NUnit.Framework;

namespace HerokuDbConnector.Tests.Unit;

public class HerokuDbConnectorTests {

    [Test]
    public void Build_DefaultOptions_ShouldReturnString() {
        // Arrange
        Environment.SetEnvironmentVariable("DATABASE_URL", TestData.GetDbUrl());
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
    public void Build_DatabaseUrl_ShouldReturnString() {
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
        npgsqlConnectionStringBuilder.SslMode.Should().Be(SslMode.Require);
        npgsqlConnectionStringBuilder.TrustServerCertificate.Should().BeTrue();
    }
    [Test]
    public void Build_SslMode_ShouldReturnString() {
        // Arrange
        Environment.SetEnvironmentVariable("DATABASE_URL", TestData.GetDbUrl());
        var herokuDbConnector = new HerokuDbConnector(o => o.SslMode = SslMode.Allow);
        // Act
        var connectionString = herokuDbConnector.Build();
        // Assert
        var npgsqlConnectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);
        npgsqlConnectionStringBuilder.Host.Should().Be(TestData.Host);
        npgsqlConnectionStringBuilder.Port.Should().Be(TestData.Port);
        npgsqlConnectionStringBuilder.Username.Should().Be(TestData.Username);
        npgsqlConnectionStringBuilder.Password.Should().Be(TestData.Password);
        npgsqlConnectionStringBuilder.Database.Should().Be(TestData.Database);
        npgsqlConnectionStringBuilder.SslMode.Should().Be(SslMode.Allow);
        npgsqlConnectionStringBuilder.TrustServerCertificate.Should().BeTrue();
    }
    [Test]
    public void Build_TrustServerCertificate_ShouldReturnString() {
        // Arrange
        Environment.SetEnvironmentVariable("DATABASE_URL", TestData.GetDbUrl());
        var herokuDbConnector = new HerokuDbConnector(o => o.TrustServerCertificate = false);
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
        npgsqlConnectionStringBuilder.TrustServerCertificate.Should().BeFalse();
    }
    [Test]
    public void Build_NullDatabaseUrl_ShouldThrowNullReferenceException() {
        // Arrange
        var herokuDbConnector = new HerokuDbConnector();
        // Act
        Action act = () => herokuDbConnector.Build();
        // Assert
        act.Should().Throw<NullReferenceException>().WithMessage("Database url has null reference");
    }
}