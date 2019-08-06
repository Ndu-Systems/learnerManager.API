using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LearnerManager.API.Contracts.RepositoryWrapper;
using LearnerManager.API.Contracts.Users;
using LearnerManager.API.Domain.Entities;
using LearnerManager.API.Domain.Repository.RepositoryWrapper;
using LearnerManager.API.Helpers;
using LearnerManager.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LearnerManager.API.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repo;
        private readonly UserManager<User> _userManager;
        public UserService(IRepositoryWrapper repo, IOptions<AppSettings> appSettings, UserManager<User> userManager)
        {
            _repo = repo;
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }
        private readonly AppSettings _appSettings;
        public LoggedInUserModel LoginUser(LoginModel model)
        {
            var validUser = _repo.User.FindAll().FirstOrDefault(x => x.Email.ToLower().Equals(model.Email.ToLower()));
            
            if (validUser == null) return null;
            var roles = (Task) _userManager.GetRolesAsync(validUser);
             // add json web token here.
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, validUser.UserName),
                    new Claim(ClaimTypes.Email, validUser.Email)
                    // TODO: Add roles
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var user = new LoggedInUserModel
            {
                UserName = validUser.UserName,
                Email = validUser.Email,
                School = validUser.School,
                Region = validUser.Region,
                Token = tokenHandler.WriteToken(token)
            };
            return user;
        }
    }
}
