using EmployeeService.Data;
using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Services.Impl
{
    public class EmployeeTypeRepository : IEmployeeTypeRepository
    {


        #region Services

        private readonly EmployeeServiceDbContext _context;

        #endregion

        #region Constructor

        public EmployeeTypeRepository(EmployeeServiceDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<Guid> Create(EmployeeType data)
        {
            await _context.EmployeeTypes.AddAsync(data);
           await _context.SaveChangesAsync();
            return data.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                EmployeeType employeeType =await GetById(id);
                if (employeeType == null)
                {
                    return false;
                    //Logger //throw new Exception("EmployeeType not found.");
                }
                _context.EmployeeTypes.RemoveRange(employeeType);
               await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

          
        }

        public async  Task<IList<EmployeeType>> GetAll()
        {
            return await _context.EmployeeTypes.ToListAsync();
        }

        public async Task<EmployeeType> GetById(Guid id)
        {
            return await _context.EmployeeTypes.FirstOrDefaultAsync(et => et.Id == id)!;
        }

        public async Task<bool> Update(EmployeeType data)
        {
            try
            {
                if (data == null)
                {
                    return false;
                    //throw new Exception("EmployeeType is null.");
                }
                    
                EmployeeType employeeType = await GetById(data.Id);
                employeeType.Description = data.Description;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }

      
    }
}
