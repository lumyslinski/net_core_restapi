# RestApp in .NET Core 2.1 and Swagger

This is a REST API based on .NET Core 2.1 and Swagger for managing Star Wars characters. It uses entity framework and local SQLite database for persistence layer. It uses also XUnit, Mock and Fluent Assertions.

Data project is separated from the Web project. To manage database You should use these commands:

- Add:
```
dotnet ef migrations add Initial
```
- Update:
```
dotnet ef database update 0
```
- Remove:
```
dotnet ef migrations remove
```
## Problems
#### 1. Relations
Entity framework does not support primitive types such as a list of string. There are two ways how to manage them:
- use a conversion from list of string to one combined string and vice versa
- use a many-to-many relation (in this example we got a character which has got episodes and friends, friends are also characters. So to remove redundancy and to not create another copy of character, there is a self-relation to characters. If we got a such a relation we should take care manually of deleting because in cascade mode we could get into circular deletion)

#### 2. Database managment
In order to generate a table in code approach we should use migrations commands as above. But, if we want to separate database project from web project then we have to move everything into another class library. To build a database context which is not configured in DI services in Startup file, we should implement [IDesignTimeDbContextFactory](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation) which will be looking by a framework in the second step. It works for ef tools as above, but if we run a web project then the DbContext could not found. As a workaround I use:
```
services.AddScoped<ApplicationDbContext>(_ => new ApplicationDbContextDesignTimeDbContextFactory().Create());
```
#### 3. Problem with Kestrel and keys
When Kestrel was running in default settings then I was receiving an error. So, I disabled SSL and https manually via a code in Program.Main.
```
Failed to authenticate HTTPS connection.
System.IO.IOException: Authentication failed because the remote party has closed the transport stream.
```
## Run in Docker
For some reason I could not set any other port than 80 as external port. Running in docker do not work yet because it does not support ms sql localdb. Resolved this by using SQLite.
```
docker stop nc2_restapp
docker rm nc2_restapp
docker build -t restapp .
docker run --name nc2_restapp -p 80:80 restapp:latest
```
