using DAL.VCS.Repository;
using DAL.VCS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VCS
{
    public class DALMissions
    {
        private readonly AppDbContext _cIDbContext;

        public DALMissions(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }

        public async Task<List<Missions>> GetMissionsByIdAsync(int id)
        {
            try
            {
                var missionsById = await (from m in _cIDbContext.Missions
                                      where m.Id == id && m.IsDeleted == false
                                      select new Missions
                                      {
                                          Id = m.Id,
                                          IsDeleted = m.IsDeleted,
                                          MissionTitle = m.MissionTitle,
                                          MissionDescription = m.MissionDescription,
                                          MissionOrganisationName = m.MissionOrganisationName,
                                          MissionOrganisationDetail = m == null ? "Nothing" : m.MissionOrganisationDetail,
                                          CountryId = m.CountryId,
                                          CityId = m.CityId,
                                          StartDate = m.StartDate,
                                          EndDate = m.EndDate,
                                          MissionType = m.MissionType,
                                          TotalSheets = m == null ? 0 : m.TotalSheets,
                                          RegistrationDeadLine = m.RegistrationDeadLine,
                                          MissionThemeId = m.MissionThemeId,
                                          MissionSkillId = m.MissionSkillId,
                                          MissionImages = m == null ? "Nothing" : m.MissionImages,
                                          MissionDocuments = m == null ? "Nothing" : m.MissionDocuments,
                                          MissionAvailability = m == null ? "Nothing" : m.MissionAvailability,
                                          MissionVideoUrl = m == null ? "Nothing" : m.MissionVideoUrl
                                      }).ToListAsync();
                return missionsById;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> CreateMissionsAsync(Missions mission)
        {
            try
            {
                var missionsDetails = await (from m in _cIDbContext.Missions where m.MissionTitle == mission.MissionTitle && m.StartDate == mission.StartDate && m.EndDate == mission.EndDate select m.MissionTitle).ToListAsync();
                if (missionsDetails.Count > 0)
                {
                    return "Mission Already Exists";
                }
                Missions createNew = new Missions();
                createNew.MissionTitle = mission.MissionTitle;
                createNew.MissionDescription = mission.MissionDescription;
                createNew.MissionOrganisationName = mission.MissionOrganisationName;
                createNew.MissionOrganisationDetail = mission.MissionOrganisationDetail;
                createNew.CountryId = mission.CountryId;
                createNew.CityId = mission.CityId;
                createNew.StartDate = mission.StartDate;
                createNew.EndDate = mission.EndDate;
                createNew.MissionType = mission.MissionType;
                createNew.TotalSheets = mission.TotalSheets;
                createNew.RegistrationDeadLine = mission.RegistrationDeadLine;
                createNew.MissionThemeId = mission.MissionThemeId;
                createNew.MissionSkillId = mission.MissionSkillId;
                createNew.MissionImages = mission.MissionImages;
                createNew.MissionDocuments = mission.MissionDocuments;
                createNew.MissionAvailability = mission.MissionAvailability;
                createNew.MissionVideoUrl = mission.MissionVideoUrl;
                createNew.Id = (from u in _cIDbContext.Missions select u.Id).Count() + 1;
                createNew.IsDeleted = false;
                _cIDbContext.Missions.Add(createNew);
                _cIDbContext.SaveChanges();
                return "Mission Created";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateMissionsAsync(Missions mission)
        {
            try
            {
                var missionsDetails = await (from m in _cIDbContext.Missions where mission.MissionTitle == m.MissionTitle select m.MissionTitle).ToListAsync();
                if (missionsDetails.Count == 0)
                {
                    return "Mission Does Not Exists";
                }
                var createNew = await (from u in _cIDbContext.Missions where u.MissionTitle == mission.MissionTitle select u).FirstOrDefaultAsync();
                createNew.MissionTitle = mission.MissionTitle;
                createNew.MissionDescription = mission.MissionDescription;
                createNew.MissionOrganisationName = mission.MissionOrganisationName;
                createNew.MissionOrganisationDetail = mission.MissionOrganisationDetail;
                createNew.CountryId = mission.CountryId;
                createNew.CityId = mission.CityId;
                createNew.StartDate = mission.StartDate;
                createNew.EndDate = mission.EndDate;
                createNew.MissionType = mission.MissionType;
                createNew.TotalSheets = mission.TotalSheets;
                createNew.RegistrationDeadLine = mission.RegistrationDeadLine;
                createNew.MissionThemeId = mission.MissionThemeId;
                createNew.MissionSkillId = mission.MissionSkillId;
                createNew.MissionImages = mission.MissionImages;
                createNew.MissionDocuments = mission.MissionDocuments;
                createNew.MissionAvailability = mission.MissionAvailability;
                createNew.MissionVideoUrl = mission.MissionVideoUrl;
                //createNew.Id = (from u in _cIDbContext.Missions select u.Id).Count() + 1;
                createNew.IsDeleted = false;
                _cIDbContext.Missions.Update(createNew);
                _cIDbContext.SaveChanges();
                return "Mission Updated";
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
                string result = "";

                using (var transaction = await _cIDbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var missionDetail = await _cIDbContext.Missions.FirstOrDefaultAsync(ud => ud.Id == missionId);
                        if (missionDetail != null)
                        {
                            missionDetail.IsDeleted = true;
                        }

                        await _cIDbContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                        result = "Deleted mission successfully!";
                        return result;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw ex;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<Missions>> MissionsDetailListAsync()
        {
            try
            {
                var missionsDetails = await (from m in _cIDbContext.Missions
                                         where !m.IsDeleted
                                         select new Missions
                                         {

                                             Id = m.Id,
                                             IsDeleted = m.IsDeleted,
                                             MissionTitle = m.MissionTitle,
                                             MissionDescription = m.MissionDescription,
                                             MissionOrganisationName = m.MissionOrganisationName,
                                             MissionOrganisationDetail = m == null ? "Nothing" : m.MissionOrganisationDetail,
                                             CountryId = m.CountryId,
                                             CityId = m.CityId,
                                             StartDate = m.StartDate,
                                             EndDate = m.EndDate,
                                             MissionType = m.MissionType,
                                             TotalSheets = m == null ? 0 : m.TotalSheets,
                                             RegistrationDeadLine = m.RegistrationDeadLine,
                                             MissionThemeId = m.MissionThemeId,
                                             MissionSkillId = m.MissionSkillId,
                                             MissionImages = m == null ? "Nothing" : m.MissionImages,
                                             MissionDocuments = m == null ? "Nothing" : m.MissionDocuments,
                                             MissionAvailability = m == null ?  "Nothing" : m.MissionAvailability,
                                             MissionVideoUrl = m == null ? "Nothing" : m.MissionVideoUrl
                                         }).ToListAsync();
                return missionsDetails;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<List<User>> GetMissionsByIdAsync(int id)
    }
}
