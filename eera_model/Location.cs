using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eera_model
{
    public class Location
    {
        public int LocationCode { get; set; }
        public int LocationID { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int RefCode { get; set; }
        public bool IsDefault { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
}
