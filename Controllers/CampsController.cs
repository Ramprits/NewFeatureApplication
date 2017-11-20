using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using New_Application.Infrastructure;
using New_Application.Repository;
using New_Application.ViewModels;

namespace New_Application.Controllers {
    [Route ("api/camps"), ValidateModel, NoCache]
    public class CampsController : Controller {
        private readonly ICampRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CampsController> _logger;
        public CampsController (ICampRepository repository, IMapper mapper, ILogger<CampsController> logger) {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCamps () {
            var getCamps = await _repository.CampsAsync ();
            return Ok (_mapper.Map<IEnumerable<CampVm>> (getCamps));
        }
    }
}