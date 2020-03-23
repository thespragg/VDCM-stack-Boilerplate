using Konscious.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using server.Helpers;
using server.Models;
using server.Services;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserService _userService;
        private IConfiguration _config;

        public AccountController(UserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost("Login")]
        public string Login(UserLogin user)
        {
            var storedUser = _userService.Find(user.Username);
            if(storedUser == null)
            {
                //Need to add a time delay here to simulate password checking
                return "";
            }

            if(VerifyHash(user.Password,storedUser.Salt, storedUser.Hash))
            {
                var jwt = new JwtProvider(_config);
                var token = jwt.GenerateSecurityToken(user.Username);
                return token;
            }
            return "";
        }

        [HttpPost("Register")]
        public bool Register(NewUser user)
        {
            //TODO: Error handling
            var salt = CreateSalt();
            var hash = HashPassword(user.Password, salt);

            //Check email isnt taken
            var newUser = new User()
            {
                Username = user.Email,
                Salt = salt,
                Hash = hash,
                Created = DateTime.Now,
                Name = user.Name,
            };

            _userService.Create(newUser);
            return true;
        }

        private byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }

        private byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 1024 * 1024
            };

            return argon2.GetBytes(16);
        }

        private bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }
    }
}