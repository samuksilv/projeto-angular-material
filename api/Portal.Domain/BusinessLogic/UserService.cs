using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Portal.Domain.Configurations;
using Portal.Domain.Contracts.BusinessLogic;
using Portal.Domain.Contracts.Repositories;
using Portal.Domain.Dtos.Request;
using Portal.Domain.Dtos.Response;
using Portal.Domain.Models;

namespace Portal.Domain.BusinessLogic {
    public class UserService : IUserService {

        private readonly SigningConfiguration _signingConfiguration;

        private readonly IUserRepository _userRepository;

        public UserService (SigningConfiguration signingConfiguration, IUserRepository userRepository) {
            _signingConfiguration = signingConfiguration;
            _userRepository = userRepository;
        }

        public async Task<UserResponse> GetByIdAsync(string id)
        {
            if( !Guid.TryParse(id, out Guid uid)  )
                throw new Exception("Id inválido");

            User user = await _userRepository.GetByIdAsync (uid);

            return (UserResponse)user;
        }

        public async Task<UserLoginResponse> LoginAsync (UserLoginRequest request) {

            User user = await _userRepository.GetUserByEmailAndPasswordAsync (request.Email, request.Password);

            if (user == null)
                throw new Exception ("Senha e/ou Email inválidos.");

            var claims = new Claim[] {
                new Claim ("Name", $"{user.FirstName} {user.LastName}"),
                new Claim ("Email", user.Email),
            };

            ClaimsIdentity identity = new ClaimsIdentity (claims);

            DateTime createdDate = DateTime.Now;
            DateTime ExpireDate = createdDate + TimeSpan.FromSeconds (TokenConfiguration.ExpireTimeInSeconds);

            var handler = new JwtSecurityTokenHandler ();

            var securityToken = handler.CreateToken (new SecurityTokenDescriptor {
                Issuer = TokenConfiguration.Issuer,
                    Audience = TokenConfiguration.Audience,
                    SigningCredentials = _signingConfiguration.SigningCredentials,
                    Subject = identity,
                    NotBefore = createdDate,
                    Expires = ExpireDate
            });

            var token = handler.WriteToken (securityToken);

            return new UserLoginResponse { Token = token };
        }

        public async Task<UserRegisterResponse> RegisterAsync (UserRegisterRequest request) {

            User user = await _userRepository.GetUserByEmailAsync (request.Email);

            if(user != null)
                throw new Exception($"O e-mail {request.Email} já está cadastrado.");

            user = (User) request;

            user.Id= Guid.NewGuid();
            var result = await _userRepository.SaveAsync(user);

            await _userRepository.SaveChangesAsync();

            UserRegisterResponse response = (UserRegisterResponse)result;
            
            return response;
        }

        
    }
}