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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService service, IMapper mapper)
        {
            _userService = service;
            _mapper = mapper;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll(string accelerationName = null, int? companyId = null)
        {
            if (accelerationName != null && companyId == null)
                return Ok(_mapper.Map<IEnumerable<UserDTO>>(_userService.FindByAccelerationName(accelerationName)));

            if (companyId != null && accelerationName == null)
                return Ok(_mapper.Map<IEnumerable<UserDTO>>(_userService.FindByCompanyId((int)companyId)));

            return NoContent();
        }

        // GET api/user/{id}
        [HttpGet("{id:int}")]
        public ActionResult<UserDTO> Get(int id)
        {
            var a = _mapper.Map<UserDTO>(_userService.FindById(id));
            return Ok(a);
        }

        //POST api/user
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_mapper.Map<UserDTO>(_userService.Save(_mapper.Map<User>(value))));
        }

    }
}
