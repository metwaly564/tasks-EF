using c_lab.context;
using c_lab.models;
using c_lab.repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_lab.Services
{
    internal class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepo;
        private readonly mycontext _db;

        public EmployeeService()
        {
            _employeeRepo = new EmployeeRepository();
            _db = new mycontext();
        }

        public void Add(Employee employee)
        {
            if (employee.Salary <= 0)
                throw new Exception("Salary must be greater than 0.");

            _employeeRepo.Add(employee);
        }

        public void Update(Employee employee)
        {
            if (employee.Salary <= 0)
                throw new Exception("Salary must be greater than 0.");

            _employeeRepo.Update(employee);
        }

        public void Delete(int id)
        {
            _employeeRepo.DeleteById(id);
        }

        public Employee GetById(int id)
        {
            return _employeeRepo.GetById(id);
        }

        public List<Employee> GetAll()
        {
            return _employeeRepo.GetAll().ToList();
        }

        public List<object> GetEmployeeSummaries()
        {
            var employees = _db.Employees
                               .Include(e => e.Department)
                               .Select(e => new
                               {
                                   e.FullName,
                                   e.Email,
                                   DepartmentName = e.Department != null ? e.Department.Name : "No Department"
                               }).ToList<object>();

            return employees;
        }
    }
}
