using DAL.VCS;
using DAL.VCS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.VCS
{
    public class BALCommon
    {
        private readonly DALCommon _dalCommon;
        ResponseResult result0 = new ResponseResult();
        CountryResultAtApiCall result = new CountryResultAtApiCall();
        CityResultAtApiCall result2 = new CityResultAtApiCall();
        MissionThemeResultAtApiCall result3 = new MissionThemeResultAtApiCall();
        MissionSkillResultAtApiCall result4 = new MissionSkillResultAtApiCall();
        MissionApplicationResultAtApiCall result5 = new MissionApplicationResultAtApiCall();

        public BALCommon(DALCommon dalCommon)
        {
            _dalCommon = dalCommon;
        }

        // ----------------------------------------------- Country ----------------------------------------------
        public async Task<CountryResultAtApiCall> GetCountryAsync()
        {
            try
            {
                var countryList = await _dalCommon.GetCountryList();
                if(countryList.Count > 0)
                {
                    result.Data = countryList;
                    result.Result = ResponseStatus.Success;
                    result.Message = "Fetched Details";
                }
                else
                {
                    result.Result = ResponseStatus.Error;
                    result.Message = "No Country List Available";
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ----------------------------------------------- Mission Theme ------------------------------------------

        public async Task<MissionThemeResultAtApiCall> GetMissionThemeAsync()
        {
            try
            {
                var missionThemeList = await _dalCommon.GetMissionThemeAsync();
                if (missionThemeList.Count > 0)
                {
                    result3.Data = missionThemeList;
                    result3.Result = ResponseStatus.Success;
                    result3.Message = "Fetched Details";
                }
                else
                {
                    result3.Result = ResponseStatus.Error;
                    result3.Message = "No Country List Available";
                }
                return result3;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MissionTheme> GetMissionThemeByIdAsync(int id)
        {
            try
            {
                var fetchedMissionTheme = await _dalCommon.GetMissionThemeByIdAsync(id);
                if (fetchedMissionTheme!= null)
                {
                    return fetchedMissionTheme;
                }
                else
                {
                    return new MissionTheme { ThemeName = "Error" };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> CreateMissionThemeAsync(MissionTheme missionTheme)
        {
            try
            {
                var missionThemeCreateResult = await _dalCommon.CreateMissionThemeAsync(missionTheme);
                if (missionThemeCreateResult == "Mission Theme Created")
                {
                    result0.Data = missionTheme.ThemeName;
                    result0.Result = ResponseStatus.Success;
                    result0.Message = missionThemeCreateResult;
                }
                else
                {
                    result0.Data = missionTheme.ThemeName;
                    result0.Result = ResponseStatus.Error;
                    result0.Message = missionThemeCreateResult;
                }
                return result0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> UpdateMissionThemeAsync(MissionTheme missionTheme)
        {
            try
            {
                var missionThemeUpdateResult = await _dalCommon.UpdateMissionThemeAsync(missionTheme);
                if (missionThemeUpdateResult == "Mission Theme Updated")
                {
                    result0.Data = missionTheme.ThemeName;
                    result0.Result = ResponseStatus.Success;
                    result0.Message = missionThemeUpdateResult;
                }
                else
                {
                    result0.Data = missionTheme.ThemeName;
                    result0.Result = ResponseStatus.Error;
                    result0.Message = missionThemeUpdateResult;
                }
                return result0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> DeleteMissionThemeAsync(int missionThemeId)
        {
            try
            {
                var result = await _dalCommon.DeleteMissionThemeAsync(missionThemeId);
                if (result == "Deleted Mission Theme successfully!")
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

        // ----------------------------------------------- Mission Skill ----------------------------------------------

        public async Task<MissionSkillResultAtApiCall> GetMissionSkillAsync()
        {
            try
            {
                var missionSkillList = await _dalCommon.GetMissionSkillList();
                if (missionSkillList.Count > 0)
                {
                    result4.Data = missionSkillList;
                    result4.Result = ResponseStatus.Success;
                    result4.Message = "Fetched Details";
                }
                else
                {
                    result4.Result = ResponseStatus.Error;
                    result4.Message = "No SKILL List Available";
                }
                return result4;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MissionSkill> GetMissionSkillByIdAsync(int id)
        {
            try
            {
                var fetchedMissionSkill = await _dalCommon.GetMissionSkillByIdAsync(id);
                if (fetchedMissionSkill != null)
                {
                    return fetchedMissionSkill;
                }
                else
                {
                    return new MissionSkill { SkillName = "Error" };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> CreateMissionSkillAsync(MissionSkill missionSkill)
        {
            try
            {
                var missionSkillCreateResult = await _dalCommon.CreateMissionSkillAsync(missionSkill);
                if (missionSkillCreateResult == "Mission Skill Created")
                {
                    result0.Data = missionSkill.SkillName;
                    result0.Result = ResponseStatus.Success;
                    result0.Message = missionSkillCreateResult;
                }
                else
                {
                    result0.Data = missionSkill.SkillName;
                    result0.Result = ResponseStatus.Error;
                    result0.Message = missionSkillCreateResult;
                }
                return result0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> UpdateMissionSkillAsync(MissionSkill missionSkill)
        {
            try
            {
                var missionSkillUpdateResult = await _dalCommon.UpdateMissionSkillAsync(missionSkill);
                if (missionSkillUpdateResult == "Mission Skill Updated")
                {
                    result0.Data = missionSkill.SkillName;
                    result0.Result = ResponseStatus.Success;
                    result0.Message = missionSkillUpdateResult;
                }
                else
                {
                    result0.Data = missionSkill.SkillName;
                    result0.Result = ResponseStatus.Error;
                    result0.Message = missionSkillUpdateResult;
                }
                return result0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> DeleteMissionSkillAsync(int missionSkillId)
        {
            try
            {
                var result = await _dalCommon.DeleteMissionSkillAsync(missionSkillId);
                if (result == "Deleted Mission Skill successfully!")
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

        // ----------------------------------------------- Mission Application ----------------------------------------------

        public async Task<MissionApplicationResultAtApiCall> GetMissionApplicationAsync()
        {
            try
            {
                var missionApplicationList = await _dalCommon.GetMissionApplicationList();
                if (missionApplicationList.Count > 0)
                {
                    result5.Data = missionApplicationList;
                    result5.Result = ResponseStatus.Success;
                    result5.Message = "Fetched Details";
                }
                else
                {
                    result5.Result = ResponseStatus.Error;
                    result5.Message = "No SKILL List Available";
                }
                return result5;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MissionApplication> GetMissionApplicationByIdAsync(int id)
        {
            try
            {
                var fetchedMissionApplication = await _dalCommon.GetMissionApplicationByIdAsync(id);
                if (fetchedMissionApplication != null)
                {
                    return fetchedMissionApplication;
                }
                else
                {
                    return new MissionApplication { MissionId = -1 };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> CreateMissionApplicationAsync(MissionApplication missionApplication)
        {
            try
            {
                var missionApplicationCreateResult = await _dalCommon.CreateMissionApplicationAsync(missionApplication);
                if (missionApplicationCreateResult == "Mission Application Created")
                {
                    result0.Data = missionApplication.MissionId.ToString();
                    result0.Result = ResponseStatus.Success;
                    result0.Message = missionApplicationCreateResult;
                }
                else
                {
                    result0.Data = missionApplication.MissionId.ToString();
                    result0.Result = ResponseStatus.Error;
                    result0.Message = missionApplicationCreateResult;
                }
                return result0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> UpdateMissionApplicationAsync(MissionApplication missionApplication)
        {
            try
            {
                var missionApplicationUpdateResult = await _dalCommon.UpdateMissionApplicationAsync(missionApplication);
                if (missionApplicationUpdateResult == "Mission Application Updated")
                {
                    result0.Data = missionApplication.MissionId.ToString();
                    result0.Result = ResponseStatus.Success;
                    result0.Message = missionApplicationUpdateResult;
                }
                else
                {
                    result0.Data = missionApplication.MissionId.ToString();
                    result0.Result = ResponseStatus.Error;
                    result0.Message = missionApplicationUpdateResult;
                }
                return result0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> DeleteMissionApplicationAsync(int missionId, int userId)
        {
            try
            {
                var result = await _dalCommon.DeleteMissionApplicationAsync(missionId, userId);
                if (result == "Deleted Mission Application successfully!")
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

        // ----------------------------------------------- City ----------------------------------------------

        public async Task<CityResultAtApiCall> GetCityAsync(int countryId)
        {
            try
            {
                var cityList = await _dalCommon.GetCityList(countryId);
                if (cityList.Count > 0)
                {
                    result2.Data = cityList;
                    result2.Result = ResponseStatus.Success;
                    result2.Message = "Fetched Details";
                }
                else
                {
                    result2.Result = ResponseStatus.Error;
                    result2.Message = "No City List Available";
                }
                return result2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // --------------------------------------------------------- User Apply ---------------------------------------------------------
        public async Task<ResponseResult> UserApplyMission(MissionApplicationForAPI missionApplication)
        {
            try
            {
                var userApplication = await _dalCommon.UserApplyMission(missionApplication);
                if (userApplication == "1")
                {
                    result0.Data = "1";
                    result0.Result = ResponseStatus.Success;
                    result0.Message = "Mission Applied";
                }
                else
                {
                    result0.Data = missionApplication.MissionId.ToString();
                    result0.Result = ResponseStatus.Error;
                    result0.Message = "Error Applying";
                }
                return result0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
