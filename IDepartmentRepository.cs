using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_DEMO.NET_
{
    internal interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();

    }


}