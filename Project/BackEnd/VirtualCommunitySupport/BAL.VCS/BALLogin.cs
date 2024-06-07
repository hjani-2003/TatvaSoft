using DAL.VCS;
using DAL.VCS.Repository.Entities;
using DAL.VCS.JWTService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.VCS
{
    public class BALLogin
    {
        private readonly DALLogin _dalLogin;
        private readonly JWTService _jwtService;
        ResponseResult result = new ResponseResult();
        public BALLogin(DALLogin dalLogin, JWTService jwtService)
        //public BALLogin(DALLogin dalLogin)
        {
            _dalLogin = dalLogin;
            _jwtService = jwtService;
        }

        public ResponseResult LoginUser(User user)
        {
            try
            {
                User userObj = new User();
                userObj = UserLogin(user);

                if (userObj != null)
                {
                    if (userObj.Message.ToString() == "Login Successful!")
                    {
                        result.Message = userObj.Message;
                        result.Result = ResponseStatus.Success;
                        //result.Data = _jwtService.GenerateToken(userObj.Id.ToString(), userObj.FirstName, userObj.LastName, userObj.PhoneNumber, userObj.EmailAddress, userObj.UserType, userObj.Password);
                        result.Data = _jwtService.GenerateToken(userObj.EmailAddress, userObj.UserType, userObj.Password, userObj.Id);
                        //result.Data = userObj.EmailAddress/*"Successful Login!"*/;
                    }
                    else
                    {
                        result.Message = userObj.Message;
                        result.Result = ResponseStatus.Error;
                    }
                }
                else
                {
                    result.Message = "Error in Login!";
                    result.Result = ResponseStatus.Error;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public User UserLogin(User user)
        {
            User userOb = new User()
            {
                EmailAddress = user.EmailAddress,
                Password = user.Password,
                UserType = user.UserType,
                Id = user.Id
            };
            return _dalLogin.LoginUser(userOb);
        }
    }
}
