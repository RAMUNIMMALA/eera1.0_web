using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eera_model
{
    public class PartnerEnquiry
    {
        public int PartnerQueryCode { get; set; }
        public int UserCode { get; set; }
        public string OrganizationName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
