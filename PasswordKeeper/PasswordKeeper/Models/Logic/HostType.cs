using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PasswordKeeper.Models.Logic
{
    public class HostType : PasswordKeeperBase 
    {

        [MaxLength(50,ErrorMessage ="Description Cannot Be More Than 50 Characters")]
        public string Description { get; set; }
        
        

    }
}