using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestAzureApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IConfiguration configuration,
                               ILogger<UsersController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet]
        public UsersViewModel Get()
        {
            _logger.LogInformation("Getting users data.");
            _logger.LogInformation("Generating random users data.");

            _logger.LogInformation(_configuration["UserSettings:Name"].ToString());
            var user = new UsersViewModel
            {
                Name = _configuration["UserSettings:Name"],
                Age = _configuration["UserSettings:Age"],
                Email = _configuration["UserSettings:Email"],
                City = _configuration["UserSettings:City"],
                Gender = _configuration["UserSettings:Gender"]
            };

            return user;
        }
    }
}
