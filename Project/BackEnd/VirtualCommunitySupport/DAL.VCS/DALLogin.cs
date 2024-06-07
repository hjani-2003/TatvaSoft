using DAL.VCS.Repository.Entities;
using DAL.VCS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VCS
{
    public class DALLogin
    {
        private readonly AppDbContext _cIDbContext;
        public DALLogin(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }

        //public string Register(User user) { }

        public User LoginUser(User user)
        {
            User userObj = new User();
            try
            {
                var query = from u in _cIDbContext.Users
                            where u.EmailAddress == user.EmailAddress && u.IsDeleted == false
                            select new
                            {
                                u.Id,
                                u.FirstName,
                                u.LastName,
                                u.PhoneNumber,
                                u.EmailAddress,
                                u.UserType,
                                u.Password,
                                UserImage = u.UserImage
                            };

                var userData = query.FirstOrDefault();
                if (userData != null)
                {
                    if (userData.Password == user.Password)
                    {
                        userObj.Id = userData.Id;
                        userObj.FirstName = user.FirstName;
                        userObj.LastName = user.LastName;
                        userObj.PhoneNumber = user.PhoneNumber;
                        userObj.EmailAddress = user.EmailAddress;
                        userObj.UserType = user.UserType;
                        userObj.UserImage = user.UserImage;
                        userObj.Message = "Login Successful!";
                    }
                    else
                    {
                        userObj.Message = "Incorrect Password!";
                    }

                }
                else
                {
                    userObj.Message = "Email Address Not Found! LOL";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userObj;
        }
    }
}
