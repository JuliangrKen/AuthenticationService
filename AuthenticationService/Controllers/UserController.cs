using Microsoft.AspNetCore.Mvc;
using System;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private ILogger logger;

        public UserController(ILogger logger)
        {
            this.logger = logger;

            logger.WriteEvent("Event");
            logger.WriteError("Error");
        }

        [HttpGet]
        public User GetUser()
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Login = "test",
                FirstName = "Test",
                LastName = "Tester",
                Email = "Test@mail.ru",
                Password = "ru",
            };
        }
    }
}
