using BAL.VCS;
using DAL.VCS.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VirtualCommunitySupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly BALAdminUser _balAdminUser;

        public AdminUserController(BALAdminUser balAdminUser)
        {
            _balAdminUser = balAdminUser;
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var userDetailList = await _balAdminUser.GetUserByIdAsync(id);

                return Ok(userDetailList); /*new User { Data = userDetailList.Data "Hi" userDetailList.ToString() Result = userDetailList.Result, Message = userDetailList.Message });*/
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser([FromBody] AddUser user)
        {
            try
            {
                var userDetailList = await _balAdminUser.CreateUserAsync(user);

                return Ok(new ResponseResult { Data = userDetailList.Data /* "Hi" userDetailList.ToString()*/, Result = userDetailList.Result, Message = userDetailList.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }
        [HttpGet("UserDetailList")]
        public async Task<IActionResult> GetUserDetailList()
        {
            try
            {
                var userDetailList = await _balAdminUser.UserDetailListAsync();

                return Ok(new ResultAtApiCall { Data = userDetailList.Data /* "Hi" userDetailList.ToString()*/, Result = userDetailList.Result, Message = userDetailList.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpDelete("DeleteUserAndUserDetail/{userId}")]
        public async Task<IActionResult> DeleteUserAndUserDetail(int userId)
        {
            try
            {
                var result = await _balAdminUser.DeleteUserAndUserDetailAsync(userId);
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }
    }
}
