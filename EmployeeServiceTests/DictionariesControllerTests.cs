using EmployeeService.Controllers;
using EmployeeService.Data;
using EmployeeService.Models;
using EmployeeService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServiceTests
{
    public class DictionariesControllerTests
    {
        private readonly DictionariesController _dictionariesController;
        private readonly Mock<IEmployeeTypeRepository> _mockEmployeeTypeRepository;
        private readonly Mock<ILogger<DictionariesController>> _ILogger;
       // ILogger<DictionariesController> _logger;
        public DictionariesControllerTests()
        {
            _mockEmployeeTypeRepository = new Mock<IEmployeeTypeRepository>();

            _dictionariesController = new DictionariesController(_mockEmployeeTypeRepository.Object, _ILogger.Object);
        }

        [Fact]
        public void GetAllEmployeeTypesTest()
        {
            // [1] Подготовка данных
            _mockEmployeeTypeRepository.Setup(repository =>
                repository.GetAll()).Returns(funresult);
            


            // [2] Исполнение тестируемого метода
            var result = _dictionariesController.GetAllEmployeeTypes();

            _mockEmployeeTypeRepository.Verify(repository =>
            repository.GetAll(), Times.Once());

           // [3] Подготовка эталонного результата и проверка на валидность
           //Assert.IsAssignableFrom<ActionResult<IList<EmployeeTypeDto>>> (result);
        }

        private Task<IList<EmployeeType>> funresult()
        {
            IList<EmployeeType> res = new List<EmployeeType>();
            return Task.FromResult(res);
        }

        [Theory]
        [InlineData("test1")]
        [InlineData("test2")]
        [InlineData("test3")]
        public void CreateEmployeeTypeTest(string description)
        {

            _mockEmployeeTypeRepository.Setup(repository =>
            repository.Create(It.IsAny<EmployeeType>())).Verifiable();

            EmployeeType employeeType = new()
            {
                Description = description ///и т д...
            };

            var result = _dictionariesController.Create(employeeType);

            _mockEmployeeTypeRepository.Verify(repository =>
            repository.Create(It.IsAny<EmployeeType>()), Times.Once);

            //Assert.IsAssignableFrom<ActionResult<int>> (result);
        }

        [Theory]
        [InlineData("3432424-34-4324-3333")]
        [InlineData("34322424-34-43224-33332")]
        [InlineData("3432424-34-43224-33233")]
        public void DeleteEmployeeTypeTest(string id)
        {
            var Guids = Guid.Parse(id);
            _mockEmployeeTypeRepository.Setup(repository =>
                repository.Delete(It.IsAny<Guid>())).Verifiable();

            var result = _dictionariesController.Remove(Guids);


            _mockEmployeeTypeRepository.Verify(repository =>
                repository.Delete(It.IsAny<Guid>()), Times.Once);

            //Assert.IsAssignableFrom<IActionResult>(result);
        }



    }
}
