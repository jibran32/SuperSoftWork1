using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Supersoft.Helpers;
using WebAPI_Supersoft.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Supersoft.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly StudentDbContext _dbcontext;
        private readonly JwtTokenGenrator _tokengen;
        public ValuesController(StudentDbContext dbcomtext, IConfiguration configuration1)
        {
            var securityKey = configuration1["Jwt:Key"];
                _dbcontext = dbcomtext;
            _tokengen = new JwtTokenGenrator(securityKey);
        }
        [HttpPost]
        public IActionResult Login(StudentsLogin s)
        {
            var jwtToken = _tokengen.GenerateJwtToken(s.Username, s.Password, TimeSpan.FromMinutes(60));
            return Ok(new { Token = jwtToken });
        }
    }
}
