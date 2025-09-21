using c_lab.context;
using c_lab.models;
using c_lab.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace c_lab.Services
{
    internal class DepartmentService
    {
        private readonly DepartmentRepository _departmentRepo;
        private readonly mycontext _db;

        public DepartmentService()
        {
            _departmentRepo = new DepartmentRepository();
            _db = new mycontext();
        }

        public void Add(Department department)
        {
            _departmentRepo.Add(department);
        }

        public void Update(Department department)
        {
            _departmentRepo.Update(department);
        }

        public void Delete(int id)
        {
            _departmentRepo.DeleteById(id);
        }

        public Department GetById(int id)
        {
            return _departmentRepo.GetById(id);
        }

        public List<Department> GetAll()
        {
            return _departmentRepo.GetAll().ToList();
        }

        public Department GetDepartmentWithEmployees(int id)
        {
            return _db.Departments
                      .Include(d => d.Employees)
                      .FirstOrDefault(d => d.Id == id);
        }
    }
}
