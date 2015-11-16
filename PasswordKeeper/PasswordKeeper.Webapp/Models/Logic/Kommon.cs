using PasswordKeeper.Webapp.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordKeeper.Webapp.Models.Logic
{
    public static class Kommon
    {


        static PaswordEntities db = new PaswordEntities();

        static string userEmail = HttpContext.Current.User.Identity.Name;

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

                //set the user email of the logged in user

                var userInfo = type.GetProperty("UserEmail");

                if (userInfo != null)
                {
                    userInfo.SetValue(obj, HttpContext.Current.User.Identity.Name);

                }
            }


            
        }


        public static IEnumerable<Credential> MyCredentials()
        {
            //PaswordEntities db = new PaswordEntities();
             //string userEmail = HttpContext.Current.User.Identity.Name;
            IEnumerable<Credential> myCredentials = db.Credentials.Include("CredentialType").Include("Host").Where(c => c.UserEmail == userEmail);


            return myCredentials;


        }


        public static IEnumerable<Host> MyHosts()
        {
           

            IEnumerable<Host> myHosts = db.Hosts.Include("HostType").Where(h => h.UserEmail == userEmail);

            return myHosts;

        }
    }
}