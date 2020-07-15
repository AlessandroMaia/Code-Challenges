using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Source.DTOs;
using Source.Models;
using Source.Services;
using System.Collections;
using System.Collections.Generic;

namespace Source.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;
        private readonly IMapper _mapper;

        public SubmissionController(ISubmissionService submissionService, IMapper mapper)
        {
            _submissionService = submissionService;
            _mapper = mapper;
        }

        // GET api/submission/higherScore/4
        [HttpGet("higherScore/{challengeId:int?}")]
        public ActionResult<decimal> GetHigherScore(int? challengeId = null)
        {
            if (challengeId == null)
                return NoContent();

            return Ok(_submissionService.FindHigherScoreByChallengeId((int)challengeId));
        }

        // GET api/submission/4
        [HttpGet("{challengeId:int?}/{accelerationId:int?}")]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? challengeId = null, int? accelerationId = null)
        {
            if (challengeId != null && accelerationId != null)
                return Ok(_mapper.Map<IEnumerable<SubmissionDTO>>(_submissionService.FindByChallengeIdAndAccelerationId((int)challengeId, (int)accelerationId)));

            return NoContent();
        }

        // POST api/candidate
        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_mapper.Map<SubmissionDTO>(_submissionService.Save(_mapper.Map<Submission>(value))));
        }
    }
}
