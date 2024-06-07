using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VCS.Repository.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string CountryId { get; set; }
        public string CityName { get; set; }
    }
}
