using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordKeeper.Models.Logic
{
    public class HostType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateModified { get; set; }

    }
}