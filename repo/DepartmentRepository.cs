using c_lab.context;
using c_lab.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_lab.repo
{
    public class DepartmentRepository
    {
        mycontext _db = new mycontext();

        public void Add(Department entity)
        {
            _db.Departments.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Department entity)
        {
            _db.Departments.Update(entity);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var dept = _db.Departments.Find(id);
            if (dept != null)
            {
                _db.Departments.Remove(dept);
                _db.SaveChanges();
            }
        }

        public Department GetById(int id)
        {
            return _db.Departments.Find(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return _db.Departments.ToList();
        }
    }

}
