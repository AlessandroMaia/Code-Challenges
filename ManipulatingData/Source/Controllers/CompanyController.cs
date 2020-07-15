using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Source.DTOs;
using Source.Models;
using Source.Services;

namespace Source.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _companyService = service;
            _mapper = mapper;
        }

        // GET api/company/{id}
        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            return Ok(_mapper.Map<CompanyDTO>(_companyService.FindById(id)));
        }

        // GET api/company
        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if (accelerationId != null && userId == null)
                return Ok(_mapper.Map<IEnumerable<CompanyDTO>>(_companyService.FindByAccelerationId((int)accelerationId)));

            if (userId != null && accelerationId == null)
                return Ok(_mapper.Map<IEnumerable<CompanyDTO>>(_companyService.FindByUserId((int)userId)));

            return NoContent();
        }

        // POST api/user
        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_mapper.Map<CompanyDTO>(_companyService.Save(_mapper.Map<Company>(value))));
        }
    }
}

