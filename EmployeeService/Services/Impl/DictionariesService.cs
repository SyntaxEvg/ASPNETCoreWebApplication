using EmployeeService.Models;
using EmployeeServiceProto;
using System.Linq;
using Grpc.Core;
using static EmployeeServiceProto.DictionariesService;

namespace EmployeeService.Services.Impl
{
    public class DictionariesService : DictionariesServiceBase
    {
        private readonly IEmployeeTypeRepository _employeeTypeRepository;

        public DictionariesService(IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeTypeRepository = employeeTypeRepository;
        }

        public override Task<CreateEmployeeTypeResponse> CreateEmployeeType(CreateEmployeeTypeRequest request, ServerCallContext context)
        {
            var id = _employeeTypeRepository.Create(new Data.EmployeeType
            {
                Description = request.Description
            });
            CreateEmployeeTypeResponse response = new CreateEmployeeTypeResponse();
            response.Id = id.ToString();
            return Task.FromResult(response);
        }

        public override Task<DeleteEmployeeTypeResponse> DeleteEmployeeType(DeleteEmployeeTypeRequest request, ServerCallContext context)
        {
            if (Guid.TryParse(request.Id, out var id))
            {
                _employeeTypeRepository.Delete(id);
            }
            return Task.FromResult(new DeleteEmployeeTypeResponse());
        }

        public override async Task<GetAllEmployeeTypesResponse> GetAllEmployeeTypes(GetAllEmployeeTypesRequest request, ServerCallContext context)
        {
            GetAllEmployeeTypesResponse response = new GetAllEmployeeTypesResponse();
            var emp = await _employeeTypeRepository.GetAll();
            if (emp == null)
            {
                return await Task.FromResult(response);
            }
            response.EmployeeTypes.AddRange(emp.Select(employee =>
                new EmployeeServiceProto.EmployeeType
                {
                    Id = employee.Id.ToString(),
                    Description = employee.Description,
                    FirstName = employee.FirstName,
                    DepartmentId = employee.DepartmentId,
                    EmployeeTypeId = employee.EmployeeTypeId,
                    Salary = employee.Salary,
                    Patronymic = employee.Patronymic,
                    Surname = employee.Surname
                }).ToList());
            return await Task.FromResult(response);
        }

    }
}
