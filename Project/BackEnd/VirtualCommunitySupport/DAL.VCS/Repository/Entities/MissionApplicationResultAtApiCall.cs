using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.VCS.Repository.Entities
{
    public class MissionApplicationResultAtApiCall
    {
        public string Message { get; set; }
        public ResponseStatus Result { get; set; }
        public List<MissionApplication> Data { get; set; }
    }
}
