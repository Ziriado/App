using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1Eget.Models
{
    internal class Ip
    {
        public bool is_valid { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public string region_code { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string timezone { get; set; }
        public string isp { get; set; }
        public string address { get; set; }
    }
}
