using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Models
{
    public class DavidBowieEra
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
    }
}
