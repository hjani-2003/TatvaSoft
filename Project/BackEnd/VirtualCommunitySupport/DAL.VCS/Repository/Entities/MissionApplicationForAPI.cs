using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VCS.Repository.Entities
{
    public class MissionApplicationForAPI
    {
        public int MissionId { get; set; }
        public int UserId { get; set; }
        public int? Sheet { get; set; }
    }
}
