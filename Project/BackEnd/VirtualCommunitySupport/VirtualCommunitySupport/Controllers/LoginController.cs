using BAL.VCS;
using DAL.VCS.Repository.Entities;
using Microsoft.AspNetCore.Mvc;

namespace VirtualCommunitySupport.Controllers
{
    public class LoginController
    {
        private readonly BALLogin _balLogin;
        ResponseResult result = new ResponseResult();
        public LoginController(BALLogin balLogin)
        {
            _balLogin = balLogin;
        }

        [HttpPost]
        [Route("LoginUser")]
        //public ResponseResult LoginUser(User user)
        public ResponseResult LoginUser([FromBody] User user)
        {
            //User user = new User();
            try
            {
                //User user = new User();
                //user.EmailAddress = EmailAddress;
                //user.Password = Password;
                //user.UserType = userType;
                ResponseResult tmp = _balLogin.LoginUser(user);
                result.Data = tmp.Data;
                result.Result = ResponseStatus.Success;
                result.Message = tmp.Message;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
                //result.Message = "Buddy";
            }
            //result.Message = "User: " + user.EmailAddress + " Password: " + user.Password + " UserType: " + user.UserType ;
            return result;
        }

    }
}
