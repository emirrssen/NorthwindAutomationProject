using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult AddEmployee(Employee employee)
        {
            _employeeDal.Add(employee);
            return new SuccessResult(Messages.EmployeeAdded);
        }

        public IResult DeleteEmployee(Employee employee)
        {
            _employeeDal.Delete(employee);
            return new SuccessResult(Messages.EmployeeDeleted);
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult UpdateEmployee(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult(Messages.EmployeeUpdated);
        }

        public IDataResult<List<Employee>> GetAllEmployees()
        {
            var result = _employeeDal.GetAll();
            return new SuccessDataResult<List<Employee>>(result, Messages.EmployeesListed);
        }

        public IDataResult<Employee> GetEmployeeById(int employeeId)
        {
            var result = _employeeDal.Get(x => x.EmployeeId == employeeId);
            return new SuccessDataResult<Employee>(result, Messages.EmployeeListed);
        }
    }
}
