using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eera_model
{
    public class UserEnquiry
    {

        public int UserAuthenticationCode { set; get; }
        public string UserName { set; get; }
        public string PhoneNumber { set; get; }
        public string Email { set; get; }
        public string Option { set; get; }
        public string Description { set; get; }
        public bool Status { set; get; }
        public DateTime Date { set; get; }

    }
}
