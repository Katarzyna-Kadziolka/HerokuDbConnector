namespace HerokuDbConnector.Tests.Unit;

public class TestData {
    public const string Host = "ab1-11-123-12-123.eu-west-1.compute.amazonaws.com";
    public const int Port = 1234;
    public const string Username = "aaaaaaaaaaaaaa";
    public const string Password = "000000000000000000000000000000aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    public const string Database = "aaaaaaaaaaaaaa";

    public static string GetDbUrl() {
        return $"postgres://{Username}:{Password}@{Host}:{Port}/{Database}";
    }
}