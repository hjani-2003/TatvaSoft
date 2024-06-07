using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VCS.Repository.Entities
{
    public class Missions
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string MissionTitle { get; set; }
        public string MissionDescription { get; set; }
        public string? MissionOrganisationName { get; set; }
        public string? MissionOrganisationDetail { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? MissionType { get; set; }
        public int? TotalSheets { get; set; }
        public DateTime? RegistrationDeadLine { get; set; }
        public string MissionThemeId { get; set; }
        public string MissionSkillId { get; set; }
        public string? MissionImages { get; set; }
        public string? MissionDocuments { get; set; }
        public string? MissionAvailability { get; set; }
        public string? MissionVideoUrl { get; set; }
    }

    public class MissionApplication
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int MissionId { get; set; }
        public int UserId { get; set; }
        public DateTime AppliedDate { get; set; }
        public int Status { get; set; } = 0;
        public int? Sheet { get; set; }
    }

    public class MissionSkill
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string SkillName { get; set; }
        public string Status { get; set; }
    }

    public class MissionTheme
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string ThemeName { get; set; }
        public string Status { get; set; }
    }
}
