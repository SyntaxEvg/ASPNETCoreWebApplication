using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Models.Requests;
using EmployeeService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Services
        ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        #endregion

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateEmployeeRequest request)
        {
            _logger.LogInformation($"Create Employee{request.Surname}");
            return Ok(_employeeRepository.Create(new Employee
            {
                DepartmentId = request.DepartmentId,
                EmployeeTypeId = request.EmployeeTypeId,
                FirstName = request.FirstName,
                Patronymic = request.Patronymic,
                Salary = request.Salary,
                Surname = request.Surname
            }));
        }

        [HttpGet("get/all")]
        public ActionResult<List<EmployeeDto>> GetAllEmployees()
        {
            _logger.LogInformation($"GetAllEmployees ");
            var emp =_employeeRepository.GetAll();
            return Ok(emp.Select(employee => new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                DepartmentId = employee.DepartmentId,
                EmployeeTypeId = employee.EmployeeTypeId,
                Salary = employee.Salary,
                Patronymic = employee.Patronymic,
                Surname = employee.Surname
            }).ToList());

        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            _logger.LogInformation($"GetById Employee{id}");
            var employee =await _employeeRepository.GetById(id);
            return  Ok(new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                DepartmentId = employee.DepartmentId,
                EmployeeTypeId = employee.EmployeeTypeId,
                Salary = employee.Salary,
                Patronymic = employee.Patronymic,
                Surname = employee.Surname
            });
        }
    }
}
