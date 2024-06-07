using DAL.VCS.Repository;
using DAL.VCS.Repository.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VCS
{
    public class DALAdminUser
    {
        private readonly AppDbContext _cIDbContext;

        public DALAdminUser(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }

        public async Task<List<User>> GetUserByIdAsync(int id)
        {
            try
            {
                var userById = await (from u in _cIDbContext.Users where u.Id == id && u.IsDeleted == false select new User
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    EmailAddress = u.EmailAddress,
                    UserType = u.UserType,
                    Password = u.Password
                }).ToListAsync();


                return userById;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> CreateUserAsync(AddUser user)
        {
            try
            {
                var userDetails = await (from u in _cIDbContext.Users where u.EmailAddress == user.EmailAddress  select u.EmailAddress).ToListAsync();
                if(userDetails.Count > 0)
                {
                    return "User Already Exists";
                }
                User createNew = new User();
                createNew.EmailAddress = user.EmailAddress;
                createNew.Password = user.Password;
                createNew.FirstName = user.FirstName;
                createNew.LastName = user.LastName;
                createNew.PhoneNumber = user.PhoneNumber;
                createNew.Id = (from u in _cIDbContext.Users select u.Id).Count() + 1;
                createNew.CreatedDate = DateTime.UtcNow;
                createNew.IsDeleted = false;
                createNew.UserType = "user";
                _cIDbContext.Users.Add(createNew);
                _cIDbContext.SaveChanges();
                return "User Created";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateUserAsync(AddUser user)
        {
            try
            {
                var userDetails = await (from u in _cIDbContext.Users where u.EmailAddress == user.EmailAddress  select u.EmailAddress).ToListAsync();
                if(userDetails.Count == 0)
                {
                    return "User Does Not Exists";
                }
                var updatedUserDetails = await (from u in _cIDbContext.Users where u.EmailAddress == user.EmailAddress select u).FirstOrDefaultAsync();
                updatedUserDetails.EmailAddress = user.EmailAddress;
                updatedUserDetails.Password = user.Password;
                updatedUserDetails.FirstName = user.FirstName;
                updatedUserDetails.LastName = user.LastName;
                updatedUserDetails.PhoneNumber = user.PhoneNumber;
                updatedUserDetails.ModifiedDate = DateTime.UtcNow;
                updatedUserDetails.IsDeleted = false;
                updatedUserDetails.UserType = "user";
                _cIDbContext.Users.Update(updatedUserDetails);
                _cIDbContext.SaveChanges();
                return "User Updated";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<UserDetail>> UserDetailListAsync()
        {
            try
            {
                var userDetails = await (from u in _cIDbContext.Users
                                         join ud in _cIDbContext.Users
                                         on u.Id equals ud.Id
                                         into userDetailGroup
                                         from userDetail in userDetailGroup.DefaultIfEmpty()
                                         where !u.IsDeleted && u.UserType == "user" && !userDetail.IsDeleted
                                         select new UserDetail
                                         {
                                             Id = u.Id,
                                             FirstName = u.FirstName,
                                             LastName = u.LastName,
                                             PhoneNumber = u.PhoneNumber,
                                             EmailAddress = u.EmailAddress,
                                             UserType = u.UserType,
                                             UserId = userDetail == null ? 0 : userDetail.Id,
                                             Name = userDetail == null ? "Nothing" : u.FirstName,
                                             Surname = userDetail == null ? "Nothing" : u.LastName,
                                             EmployeeId = userDetail == null ? "Nothing" : u.Id.ToString(),
                                             Department = userDetail == null ? "Nothing" : "Nothing",
                                             Title = userDetail == null ? "Nothing" : "Nothing",
                                             Manager = userDetail == null ? "Nothing" : "Nothing",
                                             WhyIVolunteer = userDetail == null ? "Nothing" : "Nothing",
                                             CountryId = userDetail == null ? 0 : 0,
                                             CityId = userDetail == null ? 0 : 0,
                                             Availability = userDetail == null ? "Nothing" : "Nothing",
                                             LinkedInUrl = userDetail == null ? "Nothing" : "Nothing",
                                             MySkills = userDetail == null ? "Nothing" : "Nothing",
                                             UserImage = userDetail == null ? "Nothing" : "Nothing",
                                             Status = userDetail == null ? false : false
                                         }).ToListAsync();
                return userDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> DeleteUserAndUserDetailAsync(int userId)
        {
            try
            {
                string result = "";

                using(var transaction = await _cIDbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var userDetail = await _cIDbContext.UserDetail.FirstOrDefaultAsync(ud => ud.UserId == userId);
                        if (userDetail != null)
                        {
                            userDetail.IsDeleted = true;
                        }

                        var user = await _cIDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
                        if (user != null)
                        {
                            user.IsDeleted = true;
                        }

                        await _cIDbContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                        result = "Deleted user successfully!";
                        return result;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw ex;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
