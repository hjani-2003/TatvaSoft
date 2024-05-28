using Practice_Books.Data;
using Practice_Books.Models;

namespace Practice_Books.Services
{
    public class DepartmentServices
    {
        private readonly LibDbContext _departments;
        public DepartmentServices(LibDbContext departments)
        {
            _departments = departments;
              //  new List<Department>{
              //  new Department { Id = 1, Name = "School of Theatre and Arts" },
              //  new Department { Id = 2, Name = "School of Literature"},
              //  new Department { Id = 3, Name = "School of History"},
              //  new Department { Id = 4, Name = "School of Literature" },
              //  new Department { Id = 5, Name = "School of Theatre and Arts"}
        }

        public List<Department> GetAll() => _departments.Department.ToList();
        public Department GetById(int id) => _departments.Department.Find(id);
        public void Add(Department department)
        {
            _departments.Add(department);
            _departments.SaveChanges();
        }
        public void Update(Department department)
        {
            var index = _departments.Department.Find(department.Id);
            if (index != null)
            {
                index.Name = department.Name;
                _departments.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var department = _departments.Department.Find(id);
            if (department != null)
            {
                _departments.Remove(department);
                _departments.SaveChanges();
            }
        }


    }
}
