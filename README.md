# HerokuDbConnector

A simple library that facilitates the creation of a connection string with the PostgreSQL database in the Heroku cloud.

Made with .Net 6

-> [Changelog](https://github.com/Katarzyna-Kadziolka/HerokuDbConnector/blob/main/CHANGELOG.md)

### Features
- building connection string with default values:
    - database Url is getting from environment variable with key `DATABASE_URL`
    - `SslMode` is set on `Require`
    - `TrustServerCertification` is set on `true`
- possibility to modify options:
    - database Url
    - `SslMode`
    - `TrustServerCertification`

### Usage
**Configuration**

1. Add Nuget package from [here]().
2. In startup of your project:
```csharp
public void ConfigureServices(IServiceCollection services) {
    var herokuDbConnector = new HerokuDbConnector();
	services.AddApplicationDbContext(herokuDbConnector.Build();)
}
```
### Development
I am happy to accept suggestions for further development. Please feel free to add Issues :)

### Authors
- [Katarzyna Kądziołka](https://github.com/Katarzyna-Kadziolka)

### License
This project is licensed under the MIT License - see the [LICENSE](https://raw.githubusercontent.com/Katarzyna-Kadziolka/HerokuDbConnector/main/LICENSE) file for details.