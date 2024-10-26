# PointOfSaleSystem

Vilnius University, 3rd course Software Engineering Design course, group project on creating point of sales system for bars, cafes, restaurants and beauty sector (hairdresser, spa, massages, etc).

Team name: karbiratoriai

## [Naming Conventions](https://github.com/ktaranov/naming-convention/blob/master/C%23%20Coding%20Standards%20and%20Naming%20Conventions.md)

## Setup Database

Setup local Postgres database with the default credentials:

- User Id = postgres
- Password = root

To get the lastest migrations to your local database run:

- `dotnet ef database update `, if using CLI
- go to 'Tools' -> 'NuGet Package Manager' -> 'Package Manager Console' and enter `update-database`
