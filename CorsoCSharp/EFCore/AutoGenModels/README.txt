
For autogenerate model with SQL Server the command is:

dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=Northwind;Integrated Security=true;" Microsoft.EntityFrameworkCore.SqlServer --table Categories --table Products --output-dir EFCore\AutoGenModels --namespace CorsoCSharp.EFCore.AutoGenModels --data-annotations --context NorthwindContext

For SQLite the command is:
dotnet ef dbcontext scaffold "Filename=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --table Categories --table Products --output-dir EFCore\AutoGenModels --namespace CorsoCSharp.EFCore.AutoGenModels --data-annotations --context NorthwindContext

	- dbcontext scaffold = command action
	- Filename=Northwind.db or Data Source=.;Initial Catalog=Northwind;Integrated Security=true; = connection string
	- Microsoft.EntityFrameworkCore.SqlServer or Microsoft.EntityFrameworkCore.Sqlite = database provider
	- --table Categories --table Products = tables to generate
	-  --output-dir EFCore\AutoGenModels = output folder for files
	- --namespace CorsoCSharp.EFCore.AutoGenModels = namespace for classes
	- --data-annotations = to use data annotations as well as the fluent API
	- --context NorthwindContext = to rename the context 