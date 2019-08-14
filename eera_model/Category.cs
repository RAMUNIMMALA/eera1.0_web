using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace eera_model
{
    public class Category
    {
        public int CategoryCode { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string HomeImage { get; set; }
        public bool HomeImageAccess { get; set; }
        public bool HomePageAccess { get; set; }
        public int CourseCount { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }

    }
}
