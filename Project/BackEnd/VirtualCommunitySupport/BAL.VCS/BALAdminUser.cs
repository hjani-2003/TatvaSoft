using DAL.VCS;
using DAL.VCS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.VCS
{
    public class BALAdminUser
    {
        public readonly DALAdminUser _dalAdminUser;
        ResultAtApiCall result = new ResultAtApiCall();
        ResponseResult result2 = new ResponseResult();

        public BALAdminUser(DALAdminUser dalAdminUser)
        {
            _dalAdminUser = dalAdminUser;
        }

        public async Task<User> GetUserByIdAsync (int id)
        {
            try
            {
                var fetchedUser = await UserGetByIdAsync(id);
                if (fetchedUser.Count > 0)
                {
                    return fetchedUser[0];
                }
                else
                {
                    return new User { FirstName = "Error" };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResponseResult> CreateUserAsync(AddUser user)
        {
            try
            {
                var userCreateResult = await UserCreateAsync(user);
                if(userCreateResult == "User Created")
                {
                    result2.Data = user.EmailAddress;
                    result2.Result = ResponseStatus.Success;
                    result2.Message = userCreateResult;
                }
                else
                {
                    result2.Data = user.EmailAddress;
                    result2.Result = ResponseStatus.Error;
                    result2.Message = userCreateResult;
                }
                return result2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResultAtApiCall> UserDetailListAsync()
        {

            try
            {
                List<UserDetail> localresult = new List<UserDetail>();
                localresult = await SubUserDetailListAsync();
                if (localresult.Count > 0)
                {
                    result.Data = localresult;
                    result.Result = ResponseStatus.Success;
                    result.Message = "Fetched Details";
                }
                else
                {
                    result.Result = ResponseStatus.Error;
                    result.Message = "No Such User Found";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<string> DeleteUserAndUserDetailAsync(int userId)
        {
            try
            {
                var result = await SubDeleteUserAndUserDetailAsync(userId);
                if(result == "Deleted user successfully!")
                {
                    return result;
                }
                else
                {
                    return "Error in Deleting!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<User>> UserGetByIdAsync(int id)
        {
            var userById = await _dalAdminUser.GetUserByIdAsync(id);
            return userById;
        }
        public async Task<string> UserCreateAsync(AddUser user)
        {
            var userCreate = await _dalAdminUser.CreateUserAsync(user);
            return userCreate;
        }

        public async Task<List<UserDetail>> SubUserDetailListAsync()
        {
            var userDetails = await _dalAdminUser.UserDetailListAsync();
            return userDetails;
        }

        public async Task<string> SubDeleteUserAndUserDetailAsync(int userId)
        {
            var result = await _dalAdminUser.DeleteUserAndUserDetailAsync(userId);
            return result;
        }
    }
}
