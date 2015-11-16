using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasswordKeeper.Models.Logic
{
    public class Host: PasswordKeeperBase 
    {
      
        public int HostTypeID { get; set; }

        [Required]
        public string UserEmail { get; set; }
    
        public virtual HostType HostType { get; set; }

    }
}