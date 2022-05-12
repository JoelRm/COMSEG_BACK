using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.DTO.Request;
using Comseg.DTO.Response;
using Comseg.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Comseg.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        //private readonly ILogger<ConcertService> _logger;

        public UserService(IUserRepository repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;   
            _configuration = configuration;
        }

        public async Task<BaseResponseLogin<UserLoginResponse>> Login(DtoLogin request)
        {
            var response = new BaseResponseLogin<UserLoginResponse>();
            var DataUser = new UserLoginResponse();
            try
            {
                var user = await _repository.Login(request.UserLogin, request.Password);
                DataUser = _mapper.Map<UserLoginResponse?>(user);
                if (DataUser != null)
                {
                    DataUser.Token = GenerarToken(DataUser, request.UserLogin);
                }
                response.UserResponse = DataUser;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }

        private string GenerarToken(UserLoginResponse user, string userLogin)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName.ToString()),
                new Claim(ClaimTypes.Sid, userLogin.ToString())
            };

            var expiredDate = DateTime.Now.AddHours(1);

            var llavesimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:SigningKey").Value));

            var credentials = new SigningCredentials(llavesimetrica, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credentials);

            var payload = new JwtPayload(
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                claims: claims,
                notBefore: DateTime.Now,
                expires: expiredDate);

            var token = new JwtSecurityToken(header, payload);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
