using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Source.DTOs;
using Source.Services;

namespace Source.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallengeService _challengeService;
        private readonly IMapper _mapper;

        public ChallengeController(IChallengeService challengeService, IMapper mapper)
        {
            _challengeService = challengeService;
            _mapper = mapper;
        }

        // GET api/challenge
        [HttpGet]
        public ActionResult<IEnumerable<ChallengeDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if (accelerationId == null && userId == null)
                return NoContent();

            return Ok(_mapper.Map<IEnumerable<ChallengeDTO>>(_challengeService.FindByAccelerationIdAndUserId((int)accelerationId, (int)userId)));
        }

        //POST api/challenge
        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_mapper.Map<ChallengeDTO>(_challengeService.Save(_mapper.Map<Models.Challenge>(value))));
        }
    }
}
