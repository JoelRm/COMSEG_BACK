
namespace Comseg.DTO.Response
{
    public class UserLoginResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string Token { get; set; }
    }
}
