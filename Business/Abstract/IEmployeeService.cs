using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IResult AddEmployee(Employee employee);
        IResult UpdateEmployee(Employee employee);
        IResult DeleteEmployee(Employee employee);
        IDataResult<Employee> GetEmployeeById(int employeeId);
        IDataResult<List<Employee>> GetAllEmployees();
    }
}
