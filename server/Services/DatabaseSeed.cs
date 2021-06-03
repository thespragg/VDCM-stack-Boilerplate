using Microsoft.Extensions.Hosting;
using server.DAL.Interfaces;
using server.Models;
using Sodium;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace server.Services
{
    public class DatabaseSeed : IHostedService
    {
        private readonly IUserService _userService;

        public DatabaseSeed(IUserService userService) => _userService = userService;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (_userService.Get().Count != 0) return Task.CompletedTask;

            var seedFile = Path.Combine(Program.GetApplicationRoot(), "seedFile.txt");
            var text = File.ReadAllText(seedFile);
            var seeds = JsonSerializer.Deserialize<List<SeedUser>>(text);

            foreach (var seed in seeds)
            {
                const int outputLength = 128;
                var salt = PasswordHash.ScryptGenerateSalt();
                var bytePassword = Encoding.ASCII.GetBytes(seed.Password);
                var hash = PasswordHash.ScryptHashBinary(bytePassword, salt, PasswordHash.Strength.Medium, outputLength);
                var user = new User
                {
                    Email = seed.Username,
                    Salt = salt,
                    Hash = hash,
                };
                _userService.Create(user);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        private class SeedUser
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
