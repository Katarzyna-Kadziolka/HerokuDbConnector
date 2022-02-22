using Npgsql;

namespace HerokuDbConnector;

public class HerokuDbConnector {
    private readonly HerokuDbConnectionOption _dbOption = new();
    public HerokuDbConnector(Action<HerokuDbConnectionOption>? optionAction = null) {
        optionAction?.Invoke(_dbOption);
    }
    public string Build() {
        if (string.IsNullOrEmpty(_dbOption.DatabaseUrl)) {
            throw new NullReferenceException(
                "Database url was null or empty. Provide a valid database url or use default");
        }
        var databaseUri = new Uri(_dbOption.DatabaseUrl);
        var userInfo = databaseUri.UserInfo.Split(':');

        var builder = new NpgsqlConnectionStringBuilder {
            Host = databaseUri.Host,
            Port = databaseUri.Port,
            Username = userInfo[0],
            Password = userInfo[1],
            Database = databaseUri.LocalPath.TrimStart('/'),
            SslMode = _dbOption.SslMode,
            TrustServerCertificate = _dbOption.TrustServerCertificate,
            
        };

        return builder.ToString();
    }
}