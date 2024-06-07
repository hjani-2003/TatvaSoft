using DAL.VCS.Repository;
using DAL.VCS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL.VCS
{
    public class DALCommon
    {
        private readonly AppDbContext _cIDbContext;

        public DALCommon (AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }

        // ----------------------------------------------- Country ---------------------------------------------------

        public async Task<List<Country>> GetCountryList()
        {
            try
            {
                var countryList = await (from c in _cIDbContext.Country select c).ToListAsync();
                return countryList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // ----------------------------------------------- Mission Skill ---------------------------------------------------

        public async Task<List<MissionSkill>> GetMissionSkillList()
        {
            try
            {
                var missionSkillList = await (from m in _cIDbContext.MissionSkills where !m.IsDeleted select m).ToListAsync();
                return missionSkillList;
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
                var missionSkill = await (from u in _cIDbContext.MissionSkills
                                          where u.Id == id && u.IsDeleted == false
                                          select u).FirstOrDefaultAsync();


                return missionSkill;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> CreateMissionSkillAsync(MissionSkill missionSkill)
        {
            try
            {
                var createMissionSkill = await (from m in _cIDbContext.MissionSkills where m.SkillName == missionSkill.SkillName select m.SkillName).ToListAsync();
                if (createMissionSkill.Count > 0)
                {
                    return "Mission Skill Already Exists";
                }
                MissionSkill createNew = new MissionSkill();
                createNew.SkillName = missionSkill.SkillName;
                createNew.Status = missionSkill.Status;
                createNew.IsDeleted = false;
                createNew.Id = (from m in _cIDbContext.MissionSkills select m.Id).Count() + 1;
                _cIDbContext.MissionSkills.Add(createNew);
                _cIDbContext.SaveChanges();
                return "Mission Skill Created";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateMissionSkillAsync(MissionSkill missionSkill)
        {
            try
            {
                var updateMissionSkill = await (from m in _cIDbContext.MissionSkills where m.SkillName == missionSkill.SkillName select m.SkillName).ToListAsync();
                if (updateMissionSkill.Count == 0)
                {
                    return "Mission Skill Does Not Exists";
                }
                var updatedMissionSkillDetails = await (from m in _cIDbContext.MissionSkills where m.SkillName == missionSkill.SkillName select m).FirstOrDefaultAsync();
                updatedMissionSkillDetails.SkillName = missionSkill.SkillName;
                updatedMissionSkillDetails.Status = missionSkill.Status;
                updatedMissionSkillDetails.IsDeleted = false;
                _cIDbContext.MissionSkills.Update(updatedMissionSkillDetails);
                _cIDbContext.SaveChanges();
                return "Mission Skill Updated";
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
                string result = "";

                using (var transaction = await _cIDbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var missionSkillDetail = await _cIDbContext.MissionSkills.FirstOrDefaultAsync(ud => ud.Id == missionSkillId);
                        if (missionSkillDetail != null)
                        {
                            missionSkillDetail.IsDeleted = true;
                        }

                        await _cIDbContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                        result = "Deleted Mission Skill successfully!";
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

        // ----------------------------------------------- Mission Application ---------------------------------------------------

        public async Task<List<MissionApplication>> GetMissionApplicationList()
        {
            try
            {
                var missionApplicationList = await (from m in _cIDbContext.MissionApplications select m).ToListAsync();
                return missionApplicationList;
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
                var missionApplication = await (from u in _cIDbContext.MissionApplications
                                          where u.Id == id && u.IsDeleted == false
                                          select u).FirstOrDefaultAsync();


                return missionApplication;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> CreateMissionApplicationAsync(MissionApplication missionApplication)
        {
            try
            {
                var createMissionApplication = await (from m in _cIDbContext.MissionApplications where m.UserId == missionApplication.UserId select m.UserId).ToListAsync();
                if (createMissionApplication.Count > 0)
                {
                    return "Mission Application Already Exists";
                }
                MissionApplication createNew = new MissionApplication();
                createNew.MissionId = missionApplication.MissionId;
                createNew.UserId = missionApplication.UserId;
                createNew.IsDeleted = false;
                createNew.Status = missionApplication.Status;
                createNew.Sheet = missionApplication.Sheet;
                createNew.AppliedDate = DateTime.UtcNow;
                createNew.Id = (from m in _cIDbContext.MissionApplications select m.Id).Count() + 1;
                _cIDbContext.MissionApplications.Add(createNew);
                _cIDbContext.SaveChanges();
                return "Mission Application Created";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateMissionApplicationAsync(MissionApplication missionApplication)
        {
            try
            {
                var updateMissionApplication = await (from m in _cIDbContext.MissionApplications where m.UserId == missionApplication.UserId select m.UserId).ToListAsync();
                if (updateMissionApplication.Count == 0)
                {
                    return "Mission Application Does Not Exists";
                }
                var updatedMissionApplicationDetails = await (from m in _cIDbContext.MissionApplications where m.UserId == missionApplication.UserId select m).FirstOrDefaultAsync();
                updatedMissionApplicationDetails.MissionId = missionApplication.MissionId;
                updatedMissionApplicationDetails.UserId = missionApplication.UserId;
                updatedMissionApplicationDetails.IsDeleted = false;
                updatedMissionApplicationDetails.Status = missionApplication.Status;
                updatedMissionApplicationDetails.Sheet = missionApplication.Sheet;
                updatedMissionApplicationDetails.AppliedDate = DateTime.UtcNow;
                _cIDbContext.MissionApplications.Update(updatedMissionApplicationDetails);
                _cIDbContext.SaveChanges();
                return "Mission Application Updated";
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
                string result = "";

                using (var transaction = await _cIDbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var missionApplicationDetail = await _cIDbContext.MissionApplications.FirstOrDefaultAsync(ud => (ud.MissionId == missionId && ud.UserId == userId));
                        if (missionApplicationDetail != null)
                        {
                            missionApplicationDetail.IsDeleted = true;
                        }

                        await _cIDbContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                        result = "Deleted Mission Application successfully!";
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

        // ----------------------------------------------- Mission Theme ---------------------------------------------------

        public async Task<List<MissionTheme>> GetMissionThemeAsync()
        {
            try
            {
                var missionThemeList = await(from m in _cIDbContext.MissionThemes where !m.IsDeleted select m).ToListAsync();
                return missionThemeList;
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
                var missionTheme = await (from u in _cIDbContext.MissionThemes
                                      where u.Id == id && u.IsDeleted == false
                                      select u).FirstOrDefaultAsync();


                return missionTheme;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> CreateMissionThemeAsync(MissionTheme missionTheme)
        {
            try
            {
                var createMissionTheme = await (from m in _cIDbContext.MissionThemes where m.ThemeName == missionTheme.ThemeName select m.ThemeName).ToListAsync();
                if (createMissionTheme.Count > 0)
                {
                    return "Mission Theme Already Exists";
                }
                MissionTheme createNew = new MissionTheme();
                createNew.ThemeName = missionTheme.ThemeName;
                createNew.Status = missionTheme.Status;
                createNew.IsDeleted = false;
                createNew.Id = (from m in _cIDbContext.MissionThemes select m.Id).Count() + 1;
                _cIDbContext.MissionThemes.Add(createNew);
                _cIDbContext.SaveChanges();
                return "Mission Theme Created";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateMissionThemeAsync(MissionTheme missionTheme)
        {
            try
            {
                var updateMissionTheme = await (from m in _cIDbContext.MissionThemes where m.ThemeName == missionTheme.ThemeName select m.ThemeName).ToListAsync();
                if (updateMissionTheme.Count == 0)
                {
                    return "Mission Theme Does Not Exists";
                }
                var updatedMissionThemeDetails = await (from m in _cIDbContext.MissionThemes where m.ThemeName == missionTheme.ThemeName select m).FirstOrDefaultAsync();
                updatedMissionThemeDetails.ThemeName = missionTheme.ThemeName;
                updatedMissionThemeDetails.Status = missionTheme.Status;
                updatedMissionThemeDetails.IsDeleted = false;
                _cIDbContext.MissionThemes.Update(updatedMissionThemeDetails);
                _cIDbContext.SaveChanges();
                return "Mission Theme Updated";
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
                string result = "";

                using (var transaction = await _cIDbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var missionThemeDetail = await _cIDbContext.MissionThemes.FirstOrDefaultAsync(ud => ud.Id == missionThemeId);
                        if (missionThemeDetail != null)
                        {
                            missionThemeDetail.IsDeleted = true;
                        }

                        await _cIDbContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                        result = "Deleted Mission Theme successfully!";
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

        // ----------------------------------------------- City ---------------------------------------------------

        public async Task<List<City>> GetCityList(int countryId)
        {
            try
            {
                var cityList = await (from c in _cIDbContext.City where c.CountryId == countryId.ToString() select c).ToListAsync();
                return cityList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // -------------------------------------------- User Apply -------------------------------------------------------------------

        public async Task<string> UserApplyMission(MissionApplicationForAPI missionApplication)
        {
            try
            {
                var createMissionApplication = await (from m in _cIDbContext.MissionApplications 
                                                      where m.UserId == missionApplication.UserId && m.MissionId == missionApplication.MissionId 
                                                      select m.Id).ToListAsync();
                if (createMissionApplication.Count > 0)
                {
                    return "Already Applied";
                }
                MissionApplication createNewApplication = new MissionApplication();
                createNewApplication.Sheet = missionApplication.Sheet;
                createNewApplication.Status = 1;
                createNewApplication.IsDeleted = false;
                createNewApplication.AppliedDate = DateTime.UtcNow;
                createNewApplication.MissionId = missionApplication.MissionId;
                createNewApplication.UserId = missionApplication.UserId;
                createNewApplication.Id = (from m in _cIDbContext.MissionApplications select m.Id).Count() + 1;
                _cIDbContext.MissionApplications.Add(createNewApplication);
                _cIDbContext.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
