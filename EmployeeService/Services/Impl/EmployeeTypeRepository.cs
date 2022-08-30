using EmployeeService.Data;
using EmployeeService.Models;

namespace EmployeeService.Services.Impl
{
    public class EmployeeTypeRepository : IEmployeeTypeRepository
    {
        public int Create(EmployeeType data)
        {
            throw new NotImplementedException();
        }

        public IList<EmployeeType> GetAll()
        {
            throw new NotImplementedException();
        }



        Task IRepository<EmployeeType, int>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<EmployeeType> IRepository<EmployeeType, int>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<EmployeeType, int>.Update(EmployeeType data)
        {
            throw new NotImplementedException();
        }
    }
}
