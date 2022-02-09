using Npgsql;

namespace HerokuDbConnector; 

public class HerokuDbConnectionOption {
    public string? DatabaseUrl { get; set; } = Environment.GetEnvironmentVariable("DATABASE_URL");
    public SslMode SslMode { get; set; } = SslMode.Require;
    public bool TrustServerCertificate { get; set; } = true;
}