using Dapper;
using Npgsql;
using On_call_masters1.Core;
using On_call_masters1.Core.Models;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
namespace On_call_masters1DAL
{

    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddUser(User user)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string sql = "INSERT INTO \"User\" (\"name\", \"password\", \"RolesID\") VALUES (@Name, @Password, @RolesID)";
                db.Execute(sql, user);
            }
        }
    }
}


