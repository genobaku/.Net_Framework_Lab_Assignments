# .NET Lab Assignment 2

This assignment covers C# access modifiers and how they work inside the same class, same assembly, and across different assemblies using inheritance and objects.

## Projects in Solution
1. **Lab1_AccessModifiers**: Main console application containing the code for Labs 1, 2, and 3.
2. **StudentLibrary**: Class library containing the Student class definition used for cross-assembly testing (Lab 4 and 5).
3. **StudentClient**: Console application referencing StudentLibrary to test access levels from an external assembly.

## How to Run
Open the solution DotNetLabAssignment2.slnx in Visual Studio 2022 and run:
- Lab1_AccessModifiers (Runs Labs 1, 2, and 3)
- StudentClient (Runs Labs 4 and 5)

Alternatively, run from the command line:
```bash
dotnet build DotNetLabAssignment2.slnx
dotnet run --project Lab1_AccessModifiers/Lab1_AccessModifiers.csproj
dotnet run --project StudentClient/StudentClient.csproj
```
