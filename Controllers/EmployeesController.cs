using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using New_Application.Repository;
using New_Application.ViewModels;

namespace New_Application.Controllers {
    [Route ("api/Employees")]
    public class EmployeesController : Controller {
        private readonly IEmployeeRepository _repository;
        private readonly ILogger<EmployeesController> _logger;
        private readonly IMapper _mapper;

        public EmployeesController (IEmployeeRepository repository, ILogger<EmployeesController> logger, IMapper mapper) {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get () {
            var getEmployees = await _repository.GetEmployeesAsync ();
            return Ok (_mapper.Map<IEnumerable<EmployeeVm>> (getEmployees));
        }
    }
}