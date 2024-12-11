using Dapper;
using Npgsql;
using On_call_masters1.Core.Models;
using System.Collections.Generic;
using System.Data;

public class EmployeeRepository
{
    private readonly string _connectionString;

    public EmployeeRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void AddEmployee(Employee employee)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionString))
        {
            string sql = "INSERT INTO \"Employee\" (\"WorkRegionID\") VALUES (@WorkRegionID)";
            db.Execute(sql, employee);
        }
    }

    public IEnumerable<Employee> GetEmployeesByCriteria(int? workRegionID = null)
    {
        using (IDbConnection db = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM \"Employee\" WHERE (@WorkRegionID IS NULL OR \"WorkRegionID\" = @WorkRegionID)";
            return db.Query<Employee>(sql, new { WorkRegionID = workRegionID });
        }
    }
}