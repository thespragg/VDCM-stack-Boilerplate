using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using server.Helpers;
using server.Models;
using server.Services;
using Sodium;
using System;
using System.Linq;
using System.Text;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IConfiguration _config;

        public AccountController(UserService userService, IConfiguration config) => (_userService,_config) = (userService, config);

        [HttpPost("Login")]
        public IActionResult Login(string username, string password)
        {
            var storedUser = _userService.Find(username);
            if (storedUser == null) return NotFound();

            var bytePass = Encoding.ASCII.GetBytes(password);
            if (!VerifyHash(bytePass, storedUser.Salt, storedUser.Hash)) return BadRequest("Incorrect Username or Password");

            var jwt = new JwtProvider(_config);
            var token = jwt.GenerateSecurityToken(username);
            return Ok(token);
        }

        [HttpPost("Register")]
        public IActionResult Register(string username, string password, string email)
        {
            const int outputLength = 128;

            //TODO: Error handling
            var salt = PasswordHash.ScryptGenerateSalt();
            var bytePassword = Encoding.ASCII.GetBytes(password);

            var hash = PasswordHash.ScryptHashBinary(bytePassword, salt, PasswordHash.Strength.Medium, outputLength);

            //Check email isnt taken
            var newUser = new User()
            {
                Username = username,
                Salt = salt,
                Hash = hash,
                Created = DateTime.Now,
                Email = email
            };

            var user = _userService.Create(newUser);
            return Ok(user);
        }

        private static bool VerifyHash(byte[] password, byte[] salt, byte[] hash)
        {
            const int outputLength = 128;
            var providedPass =
                PasswordHash.ScryptHashBinary(password, salt, PasswordHash.Strength.Medium, outputLength);
            return hash.SequenceEqual(providedPass);
        }
    }
}