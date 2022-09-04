using EmployeeService.Data;
using EmployeeService.Models;

namespace EmployeeService.Services.Impl
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public Task<Guid> Create(Department data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Department>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Department data)
        {
            throw new NotImplementedException();
        }
    }
}
