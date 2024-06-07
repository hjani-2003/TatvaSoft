using BAL.VCS;
using DAL.VCS.Repository.Entities;
using DAL.VCS;
using Microsoft.AspNetCore.Mvc;
using DAL.VCS.Common;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;
using Microsoft.Extensions.Hosting.Internal;

namespace VirtualCommunitySupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly BALCommon _balCommon;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public CommonController (BALCommon balCommon, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _balCommon = balCommon;
            _hostingEnvironment = hostingEnvironment;
        }

        // ------------------------------------------- Country & City --------------------------------------------------

        [HttpGet("CountryList")]
        public async Task<IActionResult> GetCountry()
        {
            try
            {
                var countryList = await _balCommon.GetCountryAsync();
                return Ok (countryList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("CityList/{countryId}")]
        public async Task<IActionResult> GetCity(int countryId)
        {
            try
            {
                var cityList = await _balCommon.GetCityAsync(countryId);
                return Ok(cityList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------------------- Mission Theme --------------------------------------------------

        [HttpGet("MissionThemeList")]
        public async Task<IActionResult> GetMissionTheme()
        {
            try
            {
                var missionThemeList = await _balCommon.GetMissionThemeAsync();
                return Ok(missionThemeList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetMissionThemeById")]
        public async Task<IActionResult> GetMissionThemeById(int id)
        {
            try
            {
                var missionTheme = await _balCommon.GetMissionThemeByIdAsync(id);

                return Ok(missionTheme); /*new User { Data = userDetailList.Data "Hi" userDetailList.ToString() Result = userDetailList.Result, Message = userDetailList.Message });*/
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpPost("AddMissionTheme")]
        public async Task<IActionResult> CreateMissionTheme([FromBody] MissionTheme mission)
        {
            try
            {
                var missionThemeDetailList = await _balCommon.CreateMissionThemeAsync(mission);

                return Ok(new ResponseResult { Data = missionThemeDetailList.Data /* "Hi" userDetailList.ToString()*/, Result = missionThemeDetailList.Result, Message = missionThemeDetailList.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpPost("UpdateMissionTheme")]
        public async Task<IActionResult> UpdateMissionTheme([FromBody] MissionTheme mission)
        {
            try
            {
                var missionThemeList = await _balCommon.UpdateMissionThemeAsync(mission);

                return Ok(new ResponseResult { Data = missionThemeList.Data /* "Hi" userDetailList.ToString()*/, Result = missionThemeList.Result, Message = missionThemeList.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpDelete("DeleteMissionTheme/{missionId}")]
        public async Task<IActionResult> DeleteMissionTheme(int missionId)
        {
            try
            {
                var result = await _balCommon.DeleteMissionThemeAsync(missionId);
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        // ------------------------------------------- Mission Skill --------------------------------------------------

        [HttpGet("MissionSkillList")]
        public async Task<IActionResult> GetMissionSkill()
        {
            try
            {
                var missionSkillList = await _balCommon.GetMissionSkillAsync();
                return Ok(missionSkillList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetMissionSkillById")]
        public async Task<IActionResult> GetMissionSkillById(int id)
        {
            try
            {
                var missionSkill = await _balCommon.GetMissionSkillByIdAsync(id);

                return Ok(missionSkill); /*new User { Data = userDetailList.Data "Hi" userDetailList.ToString() Result = userDetailList.Result, Message = userDetailList.Message });*/
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpPost("AddMissionSkill")]
        public async Task<IActionResult> CreateMissionSkill([FromBody] MissionSkill mission)
        {
            try
            {
                var missionSkillDetailList = await _balCommon.CreateMissionSkillAsync(mission);

                return Ok(new ResponseResult { Data = missionSkillDetailList.Data /* "Hi" userDetailList.ToString()*/, Result = missionSkillDetailList.Result, Message = missionSkillDetailList.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpPost("UpdateMissionSkill")]
        public async Task<IActionResult> UpdateMissionSkill([FromBody] MissionSkill mission)
        {
            try
            {
                var missionSkillDetailList = await _balCommon.UpdateMissionSkillAsync(mission);

                return Ok(new ResponseResult { Data = missionSkillDetailList.Data /* "Hi" userDetailList.ToString()*/, Result = missionSkillDetailList.Result, Message = missionSkillDetailList.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpDelete("DeleteMissionSkill/{missionId}")]
        public async Task<IActionResult> DeleteMissionSkill(int missionId)
        {
            try
            {
                var result = await _balCommon.DeleteMissionSkillAsync(missionId);
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        // ------------------------------------------- Mission Application --------------------------------------------------

        [HttpGet("MissionApplicationList")]
        public async Task<IActionResult> GetMissionApplication()
        {
            try
            {
                var missionApplicationList = await _balCommon.GetMissionApplicationAsync();
                return Ok(missionApplicationList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetMissionApplicationById")]
        public async Task<IActionResult> GetMissionApplicationById(int id)
        {
            try
            {
                var missionApplication = await _balCommon.GetMissionApplicationByIdAsync(id);

                return Ok(missionApplication); /*new User { Data = userDetailList.Data "Hi" userDetailList.ToString() Result = userDetailList.Result, Message = userDetailList.Message });*/
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpPost("AddMissionApplication")]
        public async Task<IActionResult> CreateMissionApplication([FromBody] MissionApplication mission)
        {
            try
            {
                var missionApplicationDetailList = await _balCommon.CreateMissionApplicationAsync(mission);

                return Ok(new ResponseResult { Data = missionApplicationDetailList.Data /* "Hi" userDetailList.ToString()*/, Result = missionApplicationDetailList.Result, Message = missionApplicationDetailList.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpPost("UpdateMissionApplication")]
        public async Task<IActionResult> UpdateMissionApplication([FromBody] MissionApplication mission)
        {
            try
            {
                var missionApplicationDetailList = await _balCommon.UpdateMissionApplicationAsync(mission);

                return Ok(new ResponseResult { Data = missionApplicationDetailList.Data /* "Hi" userDetailList.ToString()*/, Result = missionApplicationDetailList.Result, Message = missionApplicationDetailList.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpDelete("DeleteMissionApplication/{missionId}/{userId}")]
        public async Task<IActionResult> DeleteMissionApplication(int missionId, int userId)
        {
            try
            {
                var result = await _balCommon.DeleteMissionApplicationAsync(missionId, userId);
                return Ok(new ResponseResult { Data = result, Result = ResponseStatus.Success });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("UploadImage")]
        [Authorize]
        public async Task<IActionResult> UploadImage([FromForm] UploadFile upload)
        {
            string filePath = "";
            string fullPath = "";
            List<string> fileList = new List<string>();
            var files = Request.Form.Files;
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    filePath = Path.Combine("UploadMissionImage", upload.ModuleName);
                    string fileRootPath = Path.Combine(_hostingEnvironment.WebRootPath, "UploadMissionImage", upload.ModuleName);

                    if (!Directory.Exists(fileRootPath))
                    {
                        Directory.CreateDirectory(fileRootPath);
                    }

                    string name = Path.GetFileNameWithoutExtension(fileName);
                    string extension = Path.GetExtension(fileName);
                    string fullFileName = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                    fullPath = Path.Combine(filePath, fullFileName);
                    string fullRootPath = Path.Combine(fileRootPath, fullFileName);
                    using (var stream = new FileStream(fullRootPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    fileList.Add(fullPath);
                }
            }
            return Ok(new { success = true, Data = fileList });
        }

        // ---------------------------------------------- User Apply --------------------------------------------------------------

        [HttpPost("ApplyMission")]
        public async Task<IActionResult> ApplyMission([FromBody] MissionApplicationForAPI missionApplication)
        {
            try
            {
                var userApply = await _balCommon.UserApplyMission(missionApplication);

                return Ok(new ResponseResult { Data = userApply.Data /* "Hi" userDetailList.ToString()*/, Result = userApply.Result, Message = userApply.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult { Result = ResponseStatus.Error, Message = ex.Message });
            }
        }
    }
}
