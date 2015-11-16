using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasswordKeeper.Models.Logic
{
    public class Credential : PasswordKeeperBase 
    {
        [Required]
        public int CredentialTypeID { get; set; }
        [Required]
        public int HostID { get; set; }
        [Required]
        public string UserEmail { get; set; }
        
        public string Password { get; set; }

        public virtual CredentialType CredentailType { get; set; }
        public virtual Host Host { get; set; }


    }
}