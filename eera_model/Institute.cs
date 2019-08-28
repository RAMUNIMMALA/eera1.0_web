using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eera_model
{
    public class Institute
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public string BannerImage { get; set; }
        public bool BannerImageAccess { get; set; }
        public bool SliderAccess { get; set; }
        public int StateCode { get; set; }
        public int CityCode { get; set; }
        public string CityTitle { get; set; }
        public int AreaCode { get; set; }
        public string ContactNo { get; set; }
        public string MailID { get; set; }
        public string Address { get; set; }
        public string Landmark { get; set; }
        public string GoogleLocation { get; set; }
        public bool HomePageAccess { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public string Instituename { get; set; }

    }
}
