using EmployeeService.Data;
using EmployeeService.Models;

namespace EmployeeService.Services.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public int Create(Employee data)
        {
            return 0;
            throw new NotImplementedException();
        }

        public IList<Employee> GetAll()
        {
            return new List<Employee>();
          //  throw new NotImplementedException();
        }
      
        Task IRepository<Employee, int>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<Employee> IRepository<Employee, int>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Employee, int>.Update(Employee data)
        {
            throw new NotImplementedException();
        }
    }
}
