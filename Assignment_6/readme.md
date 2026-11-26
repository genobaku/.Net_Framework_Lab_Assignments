# Lab Assignment 6

This C# console application demonstrates connected and disconnected ADO.NET operations on a SQL Server `Student` table.

It covers:

1. Read, insert, update, and delete with connected architecture (`SqlConnection`, `SqlCommand`, `SqlDataReader`).
2. Read, insert, update, and delete with disconnected architecture using `DataSet` and `SqlDataAdapter`.
3. Insert, update, and delete with `SqlCommandBuilder`.
4. A comparison of connected and disconnected architectures.

## Requirements

- .NET 10 SDK / Visual Studio 2022
- SQL Server (SQLEXPRESS, LocalDB, or default instance)

The application automatically connects to your available SQL Server instance (`.\SQLEXPRESS` or `(localdb)\MSSQLLocalDB`), creates the `StudentDB` database and `Student` table if they do not already exist, and seeds initial data.

## Running in Visual Studio

1. Open `Assignment6.sln` (or `Assignment6.csproj`) in **Visual Studio 2022**.
2. Press **F5** (or **Ctrl + F5**) to build and run.

## Running from Command Line

Open a terminal in this folder and run:

```powershell
dotnet run
```
