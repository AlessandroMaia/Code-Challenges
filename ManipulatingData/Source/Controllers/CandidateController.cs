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
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService candidateService, IMapper mapper)
        {
            _candidateService = candidateService;
            _mapper = mapper;
        }

        // GET api/candidate/5/5/5
        [HttpGet("{userId:int}/{accelerationId:int}/{companyId:int}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId)
        {
            return Ok(_mapper.Map<CandidateDTO>(_candidateService.FindById(userId, accelerationId, companyId)));
        }

        // GET api/candidate
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? companyId = null, int? accelerationId = null)
        {
            if (companyId != null && accelerationId == null)
                return Ok(_mapper.Map<IEnumerable<CandidateDTO>>(_candidateService.FindByCompanyId((int)companyId)));

            if (companyId == null && accelerationId != null)
                return Ok(_mapper.Map<IEnumerable<CandidateDTO>>(_candidateService.FindByAccelerationId((int)accelerationId)));

            return NoContent();
        }

        // POST api/candidate
        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_mapper.Map<CandidateDTO>(_candidateService.Save(_mapper.Map<Candidate>(value))));
        }
    }
}
