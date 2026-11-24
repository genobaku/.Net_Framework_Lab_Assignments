# Lab Assignment 6

This C# console application demonstrates connected and disconnected ADO.NET operations on a SQL Server `Student` table.

It covers:

1. Read, insert, update, and delete with connected architecture.
2. Read, insert, update, and delete with disconnected architecture using `DataSet` and `SqlDataAdapter`.
3. Insert, update, and delete with `SqlCommandBuilder`.
4. A comparison of connected and disconnected architectures.

## Requirements

- .NET 11 SDK
- SQL Server LocalDB

The application creates the `StudentDB` database and `Student` table in LocalDB when they do not already exist. It adds sample records when the table is empty.

## Run

Open PowerShell in the project folder and run:

```powershell
& "C:\Program Files\dotnet\dotnet.exe" run
```

Or, if `dotnet` is available on your `PATH`:

```powershell
dotnet run
```
