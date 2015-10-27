using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordKeeper.Models.Logic
{
    public class Credential
    {
        public int ID { get; set; }
        public int CredentialTypeID { get; set; }
        public int HostID { get; set; }
        public string Password { get; set; }
        public DateTime DateModified { get; set; }

        public virtual CredentialType CredentailType { get; set; }
        public virtual Host Host { get; set; }


    }
}