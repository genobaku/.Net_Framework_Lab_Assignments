using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace Assignment6;

public sealed class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public int Age { get; set; }
    public decimal Marks { get; set; }
    public string Phone { get; set; } = string.Empty;
}

public static class StudentDatabase
{
    private static readonly string ServerName = ResolveServerName();
    private const string DatabaseName = "StudentDB";
    private static readonly string ConnectionString = $"Data Source={ServerName};Initial Catalog={DatabaseName};Integrated Security=True;TrustServerCertificate=True;";
    private static readonly string MasterConnectionString = $"Data Source={ServerName};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;";

    private static string ResolveServerName()
    {
        string[] candidates = { @".\SQLEXPRESS", @"localhost\SQLEXPRESS", @"(localdb)\MSSQLLocalDB", "localhost", "." };
        foreach (var server in candidates)
        {
            try
            {
                var testConnStr = $"Data Source={server};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=2;";
                using var conn = new SqlConnection(testConnStr);
                conn.Open();
                return server;
            }
            catch
            {
                // try next candidate
            }
        }
        return @".\SQLEXPRESS";
    }

    public static void EnsureDatabaseAndTable()
    {
        using var masterConnection = new SqlConnection(MasterConnectionString);
        masterConnection.Open();

        using var databaseCheck = new SqlCommand("SELECT COUNT(*) FROM sys.databases WHERE name = @DatabaseName", masterConnection);
        databaseCheck.Parameters.AddWithValue("@DatabaseName", DatabaseName);
        var exists = (int)databaseCheck.ExecuteScalar();

        if (exists == 0)
        {
            using var createDatabase = new SqlCommand($"CREATE DATABASE [{DatabaseName}]", masterConnection);
            createDatabase.ExecuteNonQuery();
        }

        using var databaseConnection = new SqlConnection(ConnectionString);
        databaseConnection.Open();

        using var tableCommand = new SqlCommand(@"
            IF OBJECT_ID(N'dbo.Student', N'U') IS NULL
            BEGIN
                CREATE TABLE dbo.Student (
                    StudentId INT IDENTITY(1,1) PRIMARY KEY,
                    Name NVARCHAR(100) NOT NULL,
                    Department NVARCHAR(100) NOT NULL,
                    Age INT NOT NULL,
                    Marks DECIMAL(5,2) NOT NULL,
                    Phone NVARCHAR(20) NULL
                );
            END", databaseConnection);
        tableCommand.ExecuteNonQuery();

        DeleteDemoRows(databaseConnection);
        SeedInitialData(databaseConnection);
    }

    public static void DeleteDemoRows(SqlConnection? connection = null)
    {
        var shouldClose = connection is null;
        connection ??= new SqlConnection(ConnectionString);

        if (shouldClose)
        {
            connection.Open();
        }

        using var command = new SqlCommand("DELETE FROM dbo.Student WHERE Name IN ('Alice Johnson', 'Bob Wilson', 'Builder Demo');", connection);
        command.ExecuteNonQuery();

        if (shouldClose)
        {
            connection.Dispose();
        }
    }

    private static void SeedInitialData(SqlConnection connection)
    {
        if (GetStudentCount(connection) > 0)
        {
            return;
        }

        using var command = new SqlCommand(@"
            INSERT INTO dbo.Student (Name, Department, Age, Marks, Phone)
            VALUES
                ('John Smith', 'Computer Science', 19, 88.50, '9876543210'),
                ('Ava Brown', 'Electronics', 21, 91.00, '9123456780'),
                ('Noah White', 'Mechanical', 20, 83.75, '9988776655');", connection);
        command.ExecuteNonQuery();
    }

    private static int GetStudentCount(SqlConnection connection)
    {
        using var command = new SqlCommand("SELECT COUNT(*) FROM dbo.Student;", connection);
        return Convert.ToInt32(command.ExecuteScalar());
    }

    // Question 1
    public static List<Student> GetAllStudentsConnected()
    {
        var students = new List<Student>();

        using var connection = new SqlConnection(ConnectionString);
        using var command = new SqlCommand("SELECT StudentId, Name, Department, Age, Marks, Phone FROM dbo.Student ORDER BY StudentId;", connection);
        connection.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            students.Add(new Student
            {
                StudentId = reader.GetInt32(0),
                Name = reader.GetString(1),
                Department = reader.GetString(2),
                Age = reader.GetInt32(3),
                Marks = reader.GetDecimal(4),
                Phone = reader.IsDBNull(5) ? string.Empty : reader.GetString(5)
            });
        }

        return students;
    }

    // Question 2
    public static Student InsertStudentConnected(Student student)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        using var command = new SqlCommand(@"
            INSERT INTO dbo.Student (Name, Department, Age, Marks, Phone)
            VALUES (@Name, @Department, @Age, @Marks, @Phone);
            SELECT CAST(SCOPE_IDENTITY() AS INT);", connection);

        command.Parameters.AddWithValue("@Name", student.Name);
        command.Parameters.AddWithValue("@Department", student.Department);
        command.Parameters.AddWithValue("@Age", student.Age);
        command.Parameters.AddWithValue("@Marks", student.Marks);
        command.Parameters.AddWithValue("@Phone", string.IsNullOrWhiteSpace(student.Phone) ? DBNull.Value : student.Phone);

        student.StudentId = Convert.ToInt32(command.ExecuteScalar());
        return student;
    }

    // Question 3
    public static void UpdateStudentConnected(int studentId, Student updatedStudent)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        using var command = new SqlCommand(@"
            UPDATE dbo.Student
            SET Name = @Name,
                Department = @Department,
                Age = @Age,
                Marks = @Marks,
                Phone = @Phone
            WHERE StudentId = @StudentId;", connection);

        command.Parameters.AddWithValue("@StudentId", studentId);
        command.Parameters.AddWithValue("@Name", updatedStudent.Name);
        command.Parameters.AddWithValue("@Department", updatedStudent.Department);
        command.Parameters.AddWithValue("@Age", updatedStudent.Age);
        command.Parameters.AddWithValue("@Marks", updatedStudent.Marks);
        command.Parameters.AddWithValue("@Phone", string.IsNullOrWhiteSpace(updatedStudent.Phone) ? DBNull.Value : updatedStudent.Phone);

        command.ExecuteNonQuery();
    }

    // Question 4
    public static void DeleteStudentConnected(int studentId)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        using var command = new SqlCommand("DELETE FROM dbo.Student WHERE StudentId = @StudentId;", connection);
        command.Parameters.AddWithValue("@StudentId", studentId);
        command.ExecuteNonQuery();
    }

    // Question 5
    public static List<Student> GetAllStudentsDisconnected()
    {
        var students = new List<Student>();
        var table = new DataTable();

        using var connection = new SqlConnection(ConnectionString);
        using var adapter = new SqlDataAdapter("SELECT StudentId, Name, Department, Age, Marks, Phone FROM dbo.Student ORDER BY StudentId;", connection);
        adapter.Fill(table);

        foreach (DataRow row in table.Rows)
        {
            students.Add(new Student
            {
                StudentId = Convert.ToInt32(row["StudentId"]),
                Name = Convert.ToString(row["Name"]) ?? string.Empty,
                Department = Convert.ToString(row["Department"]) ?? string.Empty,
                Age = Convert.ToInt32(row["Age"]),
                Marks = Convert.ToDecimal(row["Marks"]),
                Phone = Convert.ToString(row["Phone"]) ?? string.Empty
            });
        }

        return students;
    }

    // Question 6
    public static Student InsertStudentDisconnected(Student student)
    {
        var dataSet = new DataSet();

        using var connection = new SqlConnection(ConnectionString);
        using var adapter = new SqlDataAdapter("SELECT StudentId, Name, Department, Age, Marks, Phone FROM dbo.Student ORDER BY StudentId;", connection);
        var builder = new SqlCommandBuilder(adapter);
        adapter.Fill(dataSet, "Student");

        var studentTable = dataSet.Tables["Student"] ?? throw new InvalidOperationException("Student table was not loaded.");
        var row = studentTable.NewRow();
        row["Name"] = student.Name;
        row["Department"] = student.Department;
        row["Age"] = student.Age;
        row["Marks"] = student.Marks;
        row["Phone"] = string.IsNullOrWhiteSpace(student.Phone) ? DBNull.Value : student.Phone;
        studentTable.Rows.Add(row);

        adapter.Update(dataSet, "Student");

        using var identityCommand = new SqlCommand("SELECT MAX(StudentId) FROM dbo.Student;", connection);
        connection.Open();
        student.StudentId = Convert.ToInt32(identityCommand.ExecuteScalar());
        return student;
    }

    // Question 7
    public static void UpdateStudentDisconnected(int studentId, Student updatedStudent)
    {
        var dataSet = new DataSet();

        using var connection = new SqlConnection(ConnectionString);
        using var adapter = new SqlDataAdapter("SELECT StudentId, Name, Department, Age, Marks, Phone FROM dbo.Student ORDER BY StudentId;", connection);
        var builder = new SqlCommandBuilder(adapter);
        adapter.Fill(dataSet, "Student");

        var studentTable = dataSet.Tables["Student"] ?? throw new InvalidOperationException("Student table was not loaded.");
        var row = studentTable.Rows.Cast<DataRow>().FirstOrDefault(item => Convert.ToInt32(item["StudentId"]) == studentId);
        if (row is null)
        {
            throw new InvalidOperationException($"Student with ID {studentId} was not found.");
        }

        row["Name"] = updatedStudent.Name;
        row["Department"] = updatedStudent.Department;
        row["Age"] = updatedStudent.Age;
        row["Marks"] = updatedStudent.Marks;
        row["Phone"] = string.IsNullOrWhiteSpace(updatedStudent.Phone) ? DBNull.Value : updatedStudent.Phone;

        adapter.Update(dataSet, "Student");
    }

    // Question 8
    public static void DeleteStudentDisconnected(int studentId)
    {
        var dataSet = new DataSet();

        using var connection = new SqlConnection(ConnectionString);
        using var adapter = new SqlDataAdapter("SELECT StudentId, Name, Department, Age, Marks, Phone FROM dbo.Student ORDER BY StudentId;", connection);
        var builder = new SqlCommandBuilder(adapter);
        adapter.Fill(dataSet, "Student");

        var studentTable = dataSet.Tables["Student"] ?? throw new InvalidOperationException("Student table was not loaded.");
        var row = studentTable.Rows.Cast<DataRow>().FirstOrDefault(item => Convert.ToInt32(item["StudentId"]) == studentId);
        if (row is null)
        {
            throw new InvalidOperationException($"Student with ID {studentId} was not found.");
        }

        row.Delete();
        adapter.Update(dataSet, "Student");
    }

    // Question 9
    public static void PerformCommandBuilderCrud()
    {
        var insertDataSet = new DataSet();
        using (var connection = new SqlConnection(ConnectionString))
        using (var adapter = new SqlDataAdapter("SELECT StudentId, Name, Department, Age, Marks, Phone FROM dbo.Student ORDER BY StudentId;", connection))
        {
            var builder = new SqlCommandBuilder(adapter);
            adapter.Fill(insertDataSet, "Student");
            var studentTable = insertDataSet.Tables["Student"] ?? throw new InvalidOperationException("Student table was not loaded.");
            var insertRow = studentTable.NewRow();
            insertRow["Name"] = "Builder Demo";
            insertRow["Department"] = "Data Science";
            insertRow["Age"] = 22;
            insertRow["Marks"] = 96.50m;
            insertRow["Phone"] = "7777777777";
            studentTable.Rows.Add(insertRow);
            adapter.Update(insertDataSet, "Student");
        }

        var updateDataSet = new DataSet();
        using (var connection = new SqlConnection(ConnectionString))
        using (var adapter = new SqlDataAdapter("SELECT StudentId, Name, Department, Age, Marks, Phone FROM dbo.Student ORDER BY StudentId;", connection))
        {
            var builder = new SqlCommandBuilder(adapter);
            adapter.Fill(updateDataSet, "Student");
            var studentTable = updateDataSet.Tables["Student"] ?? throw new InvalidOperationException("Student table was not loaded.");
            var rowToUpdate = studentTable.Rows.Cast<DataRow>().LastOrDefault(item => Convert.ToString(item["Name"]) == "Builder Demo");
            if (rowToUpdate is not null)
            {
                rowToUpdate["Department"] = "Artificial Intelligence";
                rowToUpdate["Marks"] = 98.75m;
                adapter.Update(updateDataSet, "Student");
            }
        }

        var deleteDataSet = new DataSet();
        using (var connection = new SqlConnection(ConnectionString))
        using (var adapter = new SqlDataAdapter("SELECT StudentId, Name, Department, Age, Marks, Phone FROM dbo.Student ORDER BY StudentId;", connection))
        {
            var builder = new SqlCommandBuilder(adapter);
            adapter.Fill(deleteDataSet, "Student");
            var studentTable = deleteDataSet.Tables["Student"] ?? throw new InvalidOperationException("Student table was not loaded.");
            var rowToDelete = studentTable.Rows.Cast<DataRow>().LastOrDefault(item => Convert.ToString(item["Name"]) == "Builder Demo");
            if (rowToDelete is not null)
            {
                rowToDelete.Delete();
                adapter.Update(deleteDataSet, "Student");
            }
        }
    }
}

public static class Program
{
    public static void Main()
    {
        try
        {
            StudentDatabase.EnsureDatabaseAndTable();
            StudentDatabase.DeleteDemoRows();
            RunConnectedCrudTasks();
            RunDisconnectedCrudTasks();
            RunCommandBuilderTask();
            ShowComparison();
        }
        catch (Exception exception)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(exception.Message);
        }
    }

    private static void RunConnectedCrudTasks()
    {
        Console.WriteLine("Task 1: Connected Architecture - Retrieve all students");
        PrintStudents(StudentDatabase.GetAllStudentsConnected());
        Console.WriteLine();

        Console.WriteLine("Task 2: Connected Architecture - Insert a new student");
        var insertedStudent = StudentDatabase.InsertStudentConnected(new Student
        {
            Name = "Alice Johnson",
            Department = "Information Technology",
            Age = 19,
            Marks = 92.50m,
            Phone = "9000000001"
        });
        Console.WriteLine($"Inserted StudentId: {insertedStudent.StudentId} Name: {insertedStudent.Name}");
        Console.WriteLine();

        Console.WriteLine("Task 3: Connected Architecture - Update a student");
        StudentDatabase.UpdateStudentConnected(insertedStudent.StudentId, new Student
        {
            StudentId = insertedStudent.StudentId,
            Name = "Alice Johnson",
            Department = "Computer Science",
            Age = 20,
            Marks = 96.25m,
            Phone = "9000000001"
        });
        PrintStudents(StudentDatabase.GetAllStudentsConnected());
        Console.WriteLine();

        Console.WriteLine("Task 4: Connected Architecture - Delete a student");
        StudentDatabase.DeleteStudentConnected(insertedStudent.StudentId);
        PrintStudents(StudentDatabase.GetAllStudentsConnected());
        Console.WriteLine();
    }

    private static void RunDisconnectedCrudTasks()
    {
        Console.WriteLine("Task 5: Disconnected Architecture - Retrieve all students with DataSet and DataAdapter");
        PrintStudents(StudentDatabase.GetAllStudentsDisconnected());
        Console.WriteLine();

        Console.WriteLine("Task 6: Disconnected Architecture - Insert a student using DataSet and DataAdapter");
        var insertedStudent = StudentDatabase.InsertStudentDisconnected(new Student
        {
            Name = "Bob Wilson",
            Department = "Networking",
            Age = 22,
            Marks = 89.75m,
            Phone = "9000000002"
        });
        Console.WriteLine($"Inserted StudentId: {insertedStudent.StudentId} Name: {insertedStudent.Name}");
        Console.WriteLine();

        Console.WriteLine("Task 7: Disconnected Architecture - Update a student using DataSet and DataAdapter");
        StudentDatabase.UpdateStudentDisconnected(insertedStudent.StudentId, new Student
        {
            StudentId = insertedStudent.StudentId,
            Name = "Bob Wilson",
            Department = "Cyber Security",
            Age = 23,
            Marks = 94.50m,
            Phone = "9000000002"
        });
        PrintStudents(StudentDatabase.GetAllStudentsDisconnected());
        Console.WriteLine();

        Console.WriteLine("Task 8: Disconnected Architecture - Delete a student using DataSet and DataAdapter");
        StudentDatabase.DeleteStudentDisconnected(insertedStudent.StudentId);
        PrintStudents(StudentDatabase.GetAllStudentsDisconnected());
        Console.WriteLine();
    }

    private static void RunCommandBuilderTask()
    {
        Console.WriteLine("Task 9: SqlCommandBuilder - Insert, Update, and Delete through DataSet");
        StudentDatabase.PerformCommandBuilderCrud();
        PrintStudents(StudentDatabase.GetAllStudentsConnected());
        Console.WriteLine();
    }

    // Question 10
    private static void ShowComparison()
    {
        Console.WriteLine("Task 10: Comparison of Connected and Disconnected ADO.NET Approaches");
        Console.WriteLine("Connected architecture:");
        Console.WriteLine("- Uses SqlConnection, SqlCommand, and SqlDataReader.");
        Console.WriteLine("- Keeps the database connection open during the operation.");
        Console.WriteLine("- Best for small, immediate, single-operation tasks where speed and direct control are needed.");
        Console.WriteLine("- Suitable for transactional operations and real-time data access.");
        Console.WriteLine();
        Console.WriteLine("Disconnected architecture:");
        Console.WriteLine("- Uses SqlDataAdapter, DataSet, and DataTable.");
        Console.WriteLine("- Copies data into memory and disconnects from the database while the application works on it.");
        Console.WriteLine("- Best for UI binding, offline editing, and batch operations.");
        Console.WriteLine("- Suitable when many operations are performed on a local copy before sending updates back.");
        Console.WriteLine();
        Console.WriteLine("Summary: Connected architecture is best for direct execution and real-time update operations, while disconnected architecture is better for working with data in memory and reducing long database connections.");
        Console.WriteLine();
    }

    private static void PrintStudents(IEnumerable<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine($"StudentId: {student.StudentId}, Name: {student.Name}, Department: {student.Department}, Age: {student.Age}, Marks: {student.Marks:F2}, Phone: {student.Phone}");
        }
    }
}

