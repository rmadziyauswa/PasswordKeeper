using System;
using System.Collections.Generic;
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

        [HiddenInput(DisplayValue = false)]
        public DateTime DateModified { get; set; }

        public string Name { get; set; }
    }
}