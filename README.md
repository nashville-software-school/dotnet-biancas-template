# Bianca's Bike Shop (.NET 10)

This branch is identical to `main` except for the .NET version it targets. Use this branch if your cohort is running .NET 10 instead of .NET 8.

## What's different from `main`
- `BiancasBikes.csproj`: `TargetFramework` is `net10.0` (was `net8.0`), and `Microsoft.AspNetCore.Identity.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.Design`, and `Npgsql.EntityFrameworkCore.PostgreSQL` are updated to `10.0` (was `8.0`). `Swashbuckle.AspNetCore` is updated to `10.2.3` (was `6.2.3`) to match.
- `.vscode/launch.json`: the debug `program` path points at `bin/Debug/net10.0/...` (was `net8.0`).

Everything else — `Program.cs`, the models, the client, the setup instructions — is unchanged. Follow the curriculum's setup chapter as normal.
