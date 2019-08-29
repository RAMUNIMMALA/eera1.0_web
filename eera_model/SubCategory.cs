using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eera_model
{
   public class SubCategory
    {
        public int SubCategoryCode { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string HomeImage { get; set; }
        public bool HomeImageAccess { get; set; }
        public bool SliderAccess { get; set; }
        public bool HomePageAccess { get; set; }
        public int CourseCount { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
}
