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
    public class AccelerationController : ControllerBase
    {
        private readonly IAccelerationService _accelerationService;
        private readonly IMapper _mapper;

        public AccelerationController(IAccelerationService accelerationService, IMapper mapper)
        {
            _accelerationService = accelerationService;
            _mapper = mapper;
        }

        // GET api/acceleration/5
        [HttpGet("{id:int}")]
        public ActionResult<AccelerationDTO> Get(int id)
        {
            return Ok(_mapper.Map<AccelerationDTO>(_accelerationService.FindById(id)));
        }

        // GET api/acceleration
        [HttpGet]
        public ActionResult<IEnumerable<AccelerationDTO>> GetAll(int? companyId = null)
        {
            if (companyId == null)
                return NoContent();

            return Ok(_mapper.Map<IEnumerable<AccelerationDTO>>(_accelerationService.FindByCompanyId((int)companyId)));
        }

        // POST api/acceleration
        [HttpPost]
        public ActionResult<AccelerationDTO> Post([FromBody] AccelerationDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_mapper.Map<AccelerationDTO>(_accelerationService.Save(_mapper.Map<Acceleration>(value))));
        }
    }
}
