using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SemearApi.Entities;
using SemearApi.Helpers;
using SemearApi.Repository.Interface;

namespace SemearApi.Service
{
    public class UserService : IUserService
    {
        
        private IUserRepositoryBase _userRepositoryBase;

        private readonly AppSettings _appSettings;
        
        
        public UserService(IOptions<AppSettings> appSettings , IUserRepositoryBase userRepositoryBase)
        {
            _appSettings = appSettings.Value;
            _userRepositoryBase = userRepositoryBase;
        }
        
        
        
        public async Task<int> CreateUser(User user )
        {
            try
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                return ( await    _userRepositoryBase.AddAsync(user)).Id;

            }
            catch (Exception e)
            {
                throw e;
            } 
            
        }
        
        public string Authenticate(string username, string password)
        {

            var user=    _userRepositoryBase.GetAll().FirstOrDefault(s => s.Email == username);
           
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password)) return null;
           
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
      
            return tokenHandler.WriteToken(token);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepositoryBase.GetAll();
        }

        public User GetById(int id) 
        {
            var user = _userRepositoryBase.GetAll().FirstOrDefault(x => x.Id == id);
            return user;
        }

        public bool VerifyExist(string username)
        {
            return _userRepositoryBase.GetAll().Count(s => s.Email == username.ToLower()) != 0;
        }

    }
}