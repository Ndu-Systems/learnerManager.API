﻿using System;
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
      
        private SignInManager<User> _signInManager;
        public UserService(IRepositoryWrapper repo, IOptions<AppSettings> appSettings, SignInManager<User> signInManager)
        {
            _repo = repo;
            _appSettings = appSettings.Value;
            _signInManager = signInManager;
        }
        private readonly AppSettings _appSettings;
        public async Task <LoggedInUserModel> LoginUser(LoginModel model)
        {

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var validUser = _repo.User.FindAll().FirstOrDefault(x => x.Email.ToLower().Equals(model.Email.ToLower()));

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

            return null;
        }
    }
}
