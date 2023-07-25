using AutoMapper;
using Domain.Service.Models.Dtos;
using Domain.Service.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebService.v1.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public AuthController(IRepositoryManager repository, IMapper mapper) : base()
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistration)
        {

            var userResult = await _repository.UserAuthentication.RegisterUserAsync(userRegistration);
            return !userResult.Succeeded ? new BadRequestObjectResult(userResult) : StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDto user)
        {
            return !await _repository.UserAuthentication.ValidateUserAsync(user)
                ? Unauthorized()
                : Ok(new { Token = await _repository.UserAuthentication.CreateTokenAsync() });
        }
    }
}
