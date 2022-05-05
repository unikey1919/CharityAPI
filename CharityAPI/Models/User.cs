using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityAPI.Models
{
    public class User
    {
        public string uid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
    }
}
