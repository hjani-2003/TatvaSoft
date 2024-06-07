using DAL.VCS;
using DAL.VCS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.VCS
{
    public class BALMissions
    {
        public readonly DALMissions _dalMissions;
        ResponseResult result2 = new ResponseResult();

        MissionsResultAtApiCall result = new MissionsResultAtApiCall();
        public BALMissions (DALMissions dalMissions)
        {
            _dalMissions = dalMissions;
        }

        public async Task<Missions> GetMissionsByIdAsync(int id)
        {
            try
            {
                var fetchedUser = await MissionsGetByIdAsync(id);
                if (fetchedUser.Count > 0)
                {
                    return fetchedUser[0];
                }
                else
                {
                    return new Missions { MissionTitle = "Error" };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseResult> CreateMissionsAsync(Missions mission)
        {
            try
            {
                var userCreateResult = await MissionsCreateAsync(mission);
                if (userCreateResult == "User Created")
                {
                    result2.Data = mission.MissionTitle;
                    result2.Result = ResponseStatus.Success;
                    result2.Message = userCreateResult;
                }
                else
                {
                    result2.Data = mission.MissionTitle;
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

        public async Task<ResponseResult> UpdateMissionsAsync(Missions mission)
        {
            try
            {
                var userCreateResult = await MissionsUpdateAsync(mission);
                if (userCreateResult == "User Updated")
                {
                    result2.Data = mission.MissionTitle;
                    result2.Result = ResponseStatus.Success;
                    result2.Message = userCreateResult;
                }
                else
                {
                    result2.Data = mission.MissionTitle;
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

        public async Task<string> DeleteMissionsAsync(int missionId)
        {
            try
            {
                var result = await SubDeleteMissionsAsync(missionId);
                if (result == "Deleted mission successfully!")
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

        public async Task<List<Missions>> MissionsGetByIdAsync(int id)
        {
            var userById = await _dalMissions.GetMissionsByIdAsync(id);
            return userById;
        }
        public async Task<string> MissionsCreateAsync(Missions mission)
        {
            var userCreate = await _dalMissions.CreateMissionsAsync(mission);
            return userCreate;
        }

        public async Task<string> MissionsUpdateAsync(Missions mission)
        {
            var userCreate = await _dalMissions.UpdateMissionsAsync(mission);
            return userCreate;
        }
        public async Task<MissionsResultAtApiCall> MissionsDetailListAsync()
        {
            try
            {
                List<Missions> localresult = new List<Missions>();
                localresult = await SubMissionsDetailListAsync();
                if (localresult.Count > 0)
                {
                    result.Data = localresult;
                    result.Result = ResponseStatus.Success;
                    result.Message = "Fetched Details";
                }
                else
                {
                    result.Result = ResponseStatus.Error;
                    result.Message = "No Mission Found";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<List<Missions>> SubMissionsDetailListAsync()
        {
            var userDetails = await _dalMissions.MissionsDetailListAsync();
            return userDetails;
        }

        public async Task<string> SubDeleteMissionsAsync(int missionId)
        {
            var result = await _dalMissions.DeleteMissionsAsync(missionId);
            return result;
        }
    }
}
