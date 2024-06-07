using BAL.VCS;
using DAL.VCS.Repository.Entities;
using DAL.VCS;
using Microsoft.AspNetCore.Mvc;

namespace VirtualCommunitySupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly BALMissions _balMissions;

        public MissionController(BALMissions balMissions)
        {
            _balMissions = balMissions;
        }

        [HttpGet("GetMissionsById")]
        public async Task<IActionResult> GetMissionsById(int id)
        {
            try
            {
                var missionsDetailList = await _balMissions.GetMissionsByIdAsync(id);
                return Ok(missionsDetailList); /*new User { Data = userDetailList.Data "Hi" userDetailList.ToString() Result = userDetailList.Result, Message = userDetailList.Message });*/
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpPost("AddMission")]
        public async Task<IActionResult> CreateMission([FromBody] Missions mission)
        {
            try
            {
                var missionDetailList = await _balMissions.CreateMissionsAsync(mission);
                return Ok(new ResponseResult { Data = missionDetailList.Data /* "Hi" userDetailList.ToString()*/, Result = missionDetailList.Result, Message = missionDetailList.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpPost("UpdateMission")]
        public async Task<IActionResult> UpdateMission([FromBody] Missions mission)
        {
            try
            {
                var missionsDetailList = await _balMissions.UpdateMissionsAsync(mission);
                return Ok(new ResponseResult { Data = missionsDetailList.Data /* "Hi" userDetailList.ToString()*/, Result = missionsDetailList.Result, Message = missionsDetailList.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpGet("MissionDetailList")]
        public async Task<IActionResult> GetMissionDetailList()
        {
            try
            {
                var missionsDetailList = await _balMissions.MissionsDetailListAsync();

                return Ok(new MissionsResultAtApiCall { Data = missionsDetailList.Data /* "Hi" userDetailList.ToString()*/, Result = missionsDetailList.Result, Message = missionsDetailList.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpDelete("DeleteMission/{missionId}")]
        public async Task<IActionResult> DeleteUserAndUserDetail(int missionId)
        {
            try
            {
                var result = await _balMissions.DeleteMissionsAsync(missionId);
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }
    }
}
