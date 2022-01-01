## ReportSharp.DatabaseReporter-1.0.5:

### Description:

DatabaseReporter for [ReportSharp](https://www.nuget.org/packages/ReportSharp) package

### Dependencies:

ReportSharp 1.0.5 or later

dotnet-ef tool 3.1 or later

Dotnet Core 3.1 or later

### Usage:

#### Note:

You need to install and configure [ReportSharp](https://www.nuget.org/packages/ReportSharp/) `1.0.5` or later to use
this package.

#### Dotnet 5 or below:

1) Add following lines to `ConfigureServices` method in `Startup` class:

```c#
services.AddReportSharp(options => {
    options.ConfigReportSharp(configBuilder =>
        configBuilder.SetWatchdogPrefix("/")
    );
    var assemblyName = typeof(Startup).Assembly.GetName().Name;
    // For request reporter
    options.AddRequestReporter(() => new DatabaseReportOptionsBuilder<ReportSharpDbContext>()
        .SetOptionsBuilder(dbOptions => {
            dbOptions.UseNpgsql(
                Configuration.GetConnectionString("DefaultConnection"),
                sql => sql.MigrationsAssembly(assemblyName)
            );
        })
    );
    // For exception reporter
    options.AddExceptionReporter(() => new DatabaseReportOptionsBuilder<ReportSharpDbContext>()
        .SetOptionsBuilder(dbOptions => {
            dbOptions.UseNpgsql(
                Configuration.GetConnectionString("DefaultConnection"),
                sql => sql.MigrationsAssembly(assemblyName)
            );
        })
    );
    // For data reporter
    options.AddDataReporter(() => new DatabaseReportOptionsBuilder<ReportSharpDbContext>()
        .SetOptionsBuilder(dbOptions => {
            dbOptions.UseNpgsql(
                Configuration.GetConnectionString("DefaultConnection"),
                sql => sql.MigrationsAssembly(assemblyName)
            );
        })
    );
    // For request, exception and data reporters
    options.AddReporter<DatabaseReporter, DatabaseReportOptionsBuilder<ReportSharpDbContext>>(
        () => new DatabaseReportOptionsBuilder<ReportSharpDbContext>()
            .SetOptionsBuilder(dbOptions => {
                dbOptions.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsAssembly(assemblyName)
                );
            })
    );
});
```

##### Note: if you want to it for all reporters, you can use only `AddReporter` method.

2) Add following lines to `Configure` method in `Startup` class:

```c#
app.UseReportSharp(configure => {
    configure.UseReportSharpMiddleware<ReportSharpMiddleware>();
});
```

3) Add ReportSharp migrations with following command in terminal:

```
dotnet ef migrations add ReportSharp -c ReportSharpDbContext
```

4) Apply ReportSharp migration on the database with following command:

```
dotnet ef database update -c ReportSharpDbContext
```

### Dotnet 6 or later:

1) Add following lines to `services` section, before `builder.Build()` line:

```c#
services.AddReportSharp(options => {
    options.ConfigReportSharp(configBuilder =>
        configBuilder.SetWatchdogPrefix("/")
    );
    var assemblyName = typeof(Startup).Assembly.GetName().Name;
    // For request reporter
    options.AddRequestReporter(() => new DatabaseReportOptionsBuilder<ReportSharpDbContext>()
        .SetOptionsBuilder(dbOptions => {
            dbOptions.UseNpgsql(
                Configuration.GetConnectionString("DefaultConnection"),
                sql => sql.MigrationsAssembly(assemblyName)
            );
        })
    );
    // For exception reporter
    options.AddExceptionReporter(() => new DatabaseReportOptionsBuilder<ReportSharpDbContext>()
        .SetOptionsBuilder(dbOptions => {
            dbOptions.UseNpgsql(
                Configuration.GetConnectionString("DefaultConnection"),
                sql => sql.MigrationsAssembly(assemblyName)
            );
        })
    );
    // For data reporter
    options.AddDataReporter(() => new DatabaseReportOptionsBuilder<ReportSharpDbContext>()
        .SetOptionsBuilder(dbOptions => {
            dbOptions.UseNpgsql(
                Configuration.GetConnectionString("DefaultConnection"),
                sql => sql.MigrationsAssembly(assemblyName)
            );
        })
    );
    // For request, exception and data reporters
    options.AddReporter<DatabaseReporter, DatabaseReportOptionsBuilder<ReportSharpDbContext>>(
        () => new DatabaseReportOptionsBuilder<ReportSharpDbContext>()
            .SetOptionsBuilder(dbOptions => {
                dbOptions.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsAssembly(assemblyName)
                );
            })
    );
});
```

##### Note: if you want to it for all reporters, you can use only `AddReporter` method.

2) Add following lines to `Configure` section, somewhere after `builder.Build()` line and before `app.Run()` line:

```c#
app.UseReportSharp(configure => {
    configure.UseReportSharpMiddleware<ReportSharpMiddleware>();
});
```

3) Add ReportSharp migrations with following command in terminal:

```
dotnet ef migrations add ReportSharp -c ReportSharpDbContext
```

4) Apply ReportSharp migration on the database with following command:

```
dotnet ef database update -c ReportSharpDbContext
```

### Donation:

#### If you like it, you can support me with `USDT`:

1) `TJ57yPBVwwK8rjWDxogkGJH1nF3TGPVq98` for `USDT TRC20`
2) `0x743379201B80dA1CB680aC08F54b058Ac01346F1` for `USDT ERC20`

