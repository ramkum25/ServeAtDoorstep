using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServeAtDoorstepData
{
    public class LoginDetails
    {

        public string UserName { set; get; }

        public string UserPassword { get; set; }

    }

    public class SendMailDetails
    {

        public string MailSubject { set; get; }

        public string MailID { get; set; }
        public string MailContent { get; set; }

    }


}
