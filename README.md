# HerokuDbConnector

Connect to your Heroku DB easily.

Made with .Net 6

-> [Changelog](https://github.com/Katarzyna-Kadziolka/HerokuDbConnector/blob/main/CHANGELOG.md)

### Features
- connect to Heroku DB using:
  - environment variable `DATABASE_URL` (default)
  - manually passed Url

### Usage
**Configuration**

1. Add Nuget package from [here]().

#### ASP

```csharp
public void ConfigureServices(IServiceCollection services) {
    services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(new HerokuDbConnector().Build()));
}
```

#### Console

```csharp
var connector = new HerokuDbConnector();
Console.WriteLine(connector.Build());

// Output: Host=ab1-11-123-12-123.eu-west-1.compute.amazonaws.com;Port=1234;Username=aaaaaaaaaaaaaa;Password=000000000000000000000000000000aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa;Database=aaaaaaaaaaaaaa;SSL Mode=Require;Trust Server Certificate=True 
```

### Development
I am happy to accept suggestions for further development. Please feel free to add Issues :)

### Authors
- [Katarzyna Kądziołka](https://github.com/Katarzyna-Kadziolka)

### License
This project is licensed under the MIT License - see the [LICENSE](https://raw.githubusercontent.com/Katarzyna-Kadziolka/HerokuDbConnector/main/LICENSE) file for details.
