using Infrastructure.MainModule.Interfaces;
using Infrastructure.MainModule.Services.Options;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace Infrastructure.MainModule.Services
{
   
    public class PasswordService : IPasswordService
    {
        private readonly PasswordOptions options;

        public PasswordService(IOptions<PasswordOptions> options)
        {
            this.options = options.Value;
        }

        public bool Check(string hash, string password)
        {
            var parts = hash.Split('.');


            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                salt,
                iterations
                ))
            {
                var keyToCheck = algorithm.GetBytes(options.KeySize);
                return keyToCheck.SequenceEqual(key);
            }
        }

        public string Hash(string password)
        {
            //Implementacion de PBKDF2
            using (var algorithm = new Rfc2898DeriveBytes(password, options.SaltSize, options.Iterations))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(options.KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{options.Iterations}.{salt}.{key}";
            }
        }
    }
}
