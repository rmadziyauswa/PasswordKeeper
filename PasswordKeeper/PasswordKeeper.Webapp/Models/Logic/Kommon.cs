using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordKeeper.Webapp.Models.Logic
{
    public class Kommon
    {

        public static void  UpdateDateModified(object obj)
        {
            Type type = obj.GetType();

            if (type != null)
            {
                var propInfo = type.GetProperty("DateModified");

                if (propInfo != null)
                {
                    propInfo.SetValue(obj, DateTime.Now);

                }
            }


            
        }
    }
}