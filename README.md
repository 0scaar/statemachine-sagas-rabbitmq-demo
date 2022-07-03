# statemachine-sagas-rabbitmq-demo

## <a name="Migration"></a> Migration
### Powershell
Creating the environment variable to enable migration and adding a migration
```
$env:DEMO_CONN = "Host=localhost;Database=postgres;Username=postgresUser;Password=postgres"
Add-Migration InitialCreate -context Context -OutputDir DataAccess/Entities/Migrations
```

