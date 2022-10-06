using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NetoBarbershop.Application.DTO;
using NetoBarbershop.Application.Interfaces;
using NetoBarbershop.Domain.Models;
using NetoBarbershop.Domain.Models.Identity;
using NetoBarbershop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbershop.Application
{
    public class TokenApplication : ITokenApplication
    {
        private readonly IGeralRepository _geralRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IConfiguration _configuration;
        private readonly IApplicationUSERRepository _applicationUSERRepository;
        private readonly UserManager<ApplicationUSER> _userManager;
        private readonly IMapper _mapper;
        private readonly SymmetricSecurityKey _key;

        public TokenApplication(IConfiguration configuration, UserManager<ApplicationUSER> userManager,
            IMapper mapper, IGeralRepository geralRepository, ITokenRepository tokenRepository,
             IApplicationUSERRepository applicationUSERRepository)
        {
            _applicationUSERRepository = applicationUSERRepository;
            _tokenRepository = tokenRepository;
            _geralRepository = geralRepository;
            _configuration = configuration;
            _userManager = userManager;
            _mapper = mapper;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }
        public async Task<TokenDTO> CreateToken(string email)
        {
            try
            {
                var usuario = await _applicationUSERRepository.GetUsersByEmailAsync(email, false);
                if (usuario == null) return null;

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,usuario.Email),
                    new Claim(ClaimTypes.NameIdentifier,usuario.Id),
                };

                var roles = await _userManager.GetRolesAsync(usuario);

                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

                var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
                var exp = DateTime.Now.AddDays(7);

                var tokenDescription = new SecurityTokenDescriptor
                {
                    Issuer = null,
                    Audience = null,
                    Subject = new ClaimsIdentity(claims),
                    Expires = exp,
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescription);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                var expRefreshToken = DateTime.UtcNow.AddDays(2);

                //Refresh Token
                var refreshtoken = Guid.NewGuid().ToString();

                var TokenDTO = new TokenDTO
                {

                    Token = tokenString,
                    Expiration = exp,
                    RefreshToken = refreshtoken,
                    ExpirationRefreshToken = expRefreshToken
                };

                var token_mapeado = _mapper.Map<Token>(TokenDTO);

                token_mapeado.Ultilizado = false;
                token_mapeado.Criado = DateTime.Now;
                token_mapeado.UsuarioID = usuario.Id;

                _geralRepository.Add<Token>(token_mapeado);

                if (await _geralRepository.SaveChangesAsync())
                {
                    return TokenDTO;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
