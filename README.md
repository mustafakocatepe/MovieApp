# Movie App

Basic movie api project . I used ASP.NET 6.0 Web API, MsSQL, Redis Cache, Swagger, Entity Framework Core.

## Getting Started

First of all, you need to clone the project to your local machine.

```
git clone https://github.com/mustafakocatepe/MovieApp.git
```

### Building

A step by step series of building that project

1. Restore the project :hammer:

```
dotnet restore
```

2. Update appsettings.json or appsettings.Development.json (Which you are working stage)

2. Change all connections for your development or production stage

3. If you want to use different Database Provider (MS SQL, MySQL etc...) You can change on Data layer File: DependencyInjection.cs (Line: 19)

```
    //For Microsoft SQL Server
    builder.Services.AddDbContext<MovieAppContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
```

5. Run EF Core Migrations

```
dotnet ef database update
```

## Running

### Run with Dotnet CLI

1. Run API project :bomb:

```
dotnet run -p ./MovieStudyCase.Api/MovieStudyCase.Api.csproj
```

## Endpoints

Swagger link

```
http://localhost:8080/swagger/index.html
```

- `GET   /api/movies` Returns movies.
- `GET   /api/movies/{id}` Returns movie by id.
- `POST  /api/movies` Creates movie.
- `PUT   /api/movies/{id}` Update movie.
- `DELETE   /api/movies/{id}` Delete movie.

## Built With

* [.NET 6.0](https://www.microsoft.com/net/) 
* [MsSQL](https://www.microsoft.com/tr-tr/sql-server) 
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - .NET ORM Tool
* [Swagger](https://swagger.io/) - API developer tools for testing and documention
* [Redis Cache](https://github.com/StackExchange/StackExchange.Redis)

## Contributing

* If you want to contribute to codes, create pull request
* If you find any bugs or error, create an issue
