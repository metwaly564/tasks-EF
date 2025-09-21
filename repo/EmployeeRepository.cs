using c_lab.context;
using c_lab.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_lab.repo
{
   
    public class EmployeeRepository 
    {
            
        mycontext _db =new mycontext();


        public void Add(Employee entity)
        {
            _db.Employees.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Employee entity)
        {
            _db.Employees.Update(entity);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var emp = _db.Employees.Find(id);
            if (emp != null)
            {
                _db.Employees.Remove(emp);
                _db.SaveChanges();
            }
        }

        public Employee GetById(int id)
        {
            return _db.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _db.Employees.ToList();
        }
    }
    
}
