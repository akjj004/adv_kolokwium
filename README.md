# adv_kolokwium

# adv csharp

## Running proj on mac

> - dotnet run --project ./Kolokwium.Web/Kolokwium.Web.csproj

## ToDos

> - Note: Add models and migrations []

## Migrations && Updates

> - dotnet ef --project ./Kolokwium.DAL/ --startup-project ./Kolokwium.Web/ migrations add Inital

> - dotnet ef database update --project ./Kolokwium.DAL/ --startup-project ./Kolokwium.Web/

dotnet ef dbcontext scaffold "Data Source=.; Initial Catalog=Northwind;Integrated Security=false; User ID=sa; Password=MyPass@word;" Microsoft.EntityFrameworkCore.SqlServer --table Categories --table Products --output-dir AutoGenModels --namespace Kolokwium.AutoGen --data-annotations --context Northwind
