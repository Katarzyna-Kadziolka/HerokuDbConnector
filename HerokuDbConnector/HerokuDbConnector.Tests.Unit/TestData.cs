namespace HerokuDbConnector.Tests.Unit;

public static class TestData {
    public static string Host => "ab1-11-123-12-123.eu-west-1.compute.amazonaws.com";
    public static int Port => 1234;
    public static string Username => "aaaaaaaaaaaaaa";
    public static string Password => "000000000000000000000000000000aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    public static string Database => "aaaaaaaaaaaaaa";

    public static string GetDbUrl() {
        return $"postgres://{Username}:{Password}@{Host}:{Port}/{Database}";
    }
}