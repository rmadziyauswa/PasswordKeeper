using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasswordKeeper.Models.Logic
{
    public class PasswordKeeperBase
    {
        public PasswordKeeperBase()
        {
            DateModified = DateTime.Now;
            Name = null;
        }

        public int ID { get; set; }

        
        public DateTime? DateModified { get; set; }

        public string Name { get; set; }
    }
}