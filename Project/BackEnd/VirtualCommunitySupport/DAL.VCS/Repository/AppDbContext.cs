using DAL.VCS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VCS.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<Missions> Missions { get; set; }
        public DbSet<MissionApplication> MissionApplications { get; set; }
        public DbSet<MissionSkill> MissionSkills { get; set; }
        public DbSet<MissionTheme> MissionThemes { get; set; }
        public DbSet<UserSkills> UserSkills { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }


    }
}
