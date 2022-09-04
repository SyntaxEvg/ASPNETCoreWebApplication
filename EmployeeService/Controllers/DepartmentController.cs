﻿using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Models.Options;
using EmployeeService.Services;
using EmployeeService.Services.Impl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EmployeeService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        #region Services

        private readonly ILogger<DepartmentController> _logger;
        private readonly IOptions<LoggerOptions> _loggerOptions;
        private readonly IDepartmentRepository _departmentRepository;

        #endregion

        #region Constructors

        public DepartmentController(
            ILogger<DepartmentController> logger,
            IOptions<LoggerOptions> loggerOptions,
            IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            _loggerOptions = loggerOptions;
            _logger = logger;
        }

        #endregion

        #region Public Methods

        [HttpGet("all")]
        public async Task<IActionResult> GetAllDepartments()
        {
            _logger.LogInformation("Department all.");
           var res=  await _departmentRepository.GetAll();
            if (res == null)
            {
                return NotFound();
            }
            return  Ok(res.Select(dep => new DepartmentDto
            {
                Id = dep.Id,
                Description = dep.Description,             
            }).ToList());
        }

        // TODO: Выполнить самостоятельно ...

        [HttpGet("departmens/get/{id}")]
        public async Task<IActionResult> GetDepartmen(Guid id)
        {
            _logger.LogInformation($"GetDepartmen {id}");
            var dep = await _departmentRepository.GetById(id);
            return Ok(new DepartmentDto()
            {
                Id = dep.Id,
                Description = dep.Description,
            });

        }
        [HttpPost("departmens/create")]
        public IActionResult GetUser(Department employee)
        {
            _logger.LogInformation($"create {employee.Description}");
            return Ok(_departmentRepository.Create(employee));
        }
        [HttpPut("departmens/update")]
        public async Task<IActionResult> Update(Department employee)
        {
            _logger.LogInformation($"Update {employee.Description}");
            await _departmentRepository.Update(employee);//лучше сразу async методы use UpdateAsync
            return Ok(200);
        }
        [HttpDelete("departmens/remove/{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            _logger.LogInformation($"Remove {id}");
            await _departmentRepository.Delete(id);//лучше сразу async методы use DeleteAsync
            return Ok(200);
        }



        #endregion

    }
}
