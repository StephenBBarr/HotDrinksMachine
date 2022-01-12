# Hot Drinks Machine - Sample Hosted Blazer Webassembly Project

### How to run
Requires Visual Studio 2019, 
         Sql Server

* The database is created using a code first approach with entity framework core.
* Migrations are created and data is seeded. 
* Open nuget package manager and run update-database command/CLI and run dotnet ef database update from the HotDrinksMachine.Server project directory.
* Database will be created on localhost in a database called HotDrinksMachine

Run the application in debug mode and run through the simple demo.
Click on your specified drink and the preparation actions will be displayed.

Created using a .NET 5 web api and blazor front end.
The DrinksController, Get endpoint returns a list of drinks that are set up to include the preparation actions by default in the Database context.
Once pulled the blazor client side runs a simple script to switch between each set of preparation actions.
Using a repository pattern to access data source.

Tests included in solution.
