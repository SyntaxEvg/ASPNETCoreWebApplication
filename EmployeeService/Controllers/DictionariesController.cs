using EmployeeService.Data;
using EmployeeService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DictionariesController : ControllerBase
    {
        ILogger<DictionariesController> _logger;
        private readonly IEmployeeTypeRepository _employeeTypeRepository;

        public DictionariesController(IEmployeeTypeRepository employeeTypeRepository,ILogger<DictionariesController> logger)
        {
            _employeeTypeRepository = employeeTypeRepository;
            _logger = logger;
        }

        [HttpGet("employee-types/all")]
        public IActionResult GetAllEmployeeTypes()
        {
            _logger.LogInformation($"all employee");
            return Ok(_employeeTypeRepository.GetAll());
        }

      
        [HttpGet("employee-types/get/{id}")]
        public IActionResult GetUser(Guid id)
        {
            _logger.LogInformation($"Get Dictionaries{id}");
            return Ok(_employeeTypeRepository.GetById(id));
        }
        [HttpPost("employee-types/add")]
        public IActionResult Create(EmployeeType employee)
        {
            _logger.LogInformation($"Create Dictionaries {employee.Description}");
            return Ok(_employeeTypeRepository.Create(employee));
        }
        [HttpPut("employee-types/update")]
        public async Task<IActionResult> Update(EmployeeType employee)
        {
            _logger.LogInformation($"update Dictionaries{employee.Id}");
            await _employeeTypeRepository.Update(employee);//лучше сразу async методы use UpdateAsync
            return Ok(200);
        }
        [HttpDelete("employee-types/remove/{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            _logger.LogInformation($"remove Dictionaries {id}");
            await _employeeTypeRepository.Delete(id);//лучше сразу async методы use DeleteAsync
            return Ok(200);
        }

    }
}
