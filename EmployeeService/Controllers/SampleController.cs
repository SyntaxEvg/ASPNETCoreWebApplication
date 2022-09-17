using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Models.Requests;
using EmployeeService.Services;
using EmployeeService.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        #region Services

        private readonly SampleObjectPool _pool;

        #endregion

        public SampleController(SampleObjectPool pool)
        {
            _pool = pool;
        }

        [HttpPost("create")]
        public ActionResult<bool> Create(int id)
        {
            return Ok(_pool.Add(id));
        }

        [HttpGet("getAll")]
        public ActionResult<List<SampleObject>> GetAll()
        {
            return Ok(_pool.GetAll());
        }

    }
}
