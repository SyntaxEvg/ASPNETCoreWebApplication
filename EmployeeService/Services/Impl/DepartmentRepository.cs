using EmployeeService.Data;
using EmployeeService.Models;

namespace EmployeeService.Services.Impl
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public Guid Create(Department data)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public Department GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Department data)
        {
            throw new NotImplementedException();
        }

        int IRepository<Department, Guid>.Create(Department data)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Department, Guid>.Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Department> IRepository<Department, Guid>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Department, Guid>.Update(Department data)
        {
            throw new NotImplementedException();
        }
    }
}
