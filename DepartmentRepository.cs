using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_DEMO.NET_
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM departments");
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO departments (Name) VALUES (@name);", new { name = newDepartmentName });
        }


        public void UpdateDepartment(int id, string newDepartmentName)
        {
            _connection.Execute("INSERT INTO departments (Name) VALUES (@name);", new { name = newDepartmentName });
        }



        public DepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }
    }
}