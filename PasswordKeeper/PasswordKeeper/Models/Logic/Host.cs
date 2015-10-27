using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordKeeper.Models.Logic
{
    public class Host
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int HostTypeID { get; set; }
        public DateTime DateModified { get; set; }

        public virtual HostType HostType { get; set; }

    }
}