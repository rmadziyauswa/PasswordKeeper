using PasswordKeeper.Models.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PasswordKeeper.Models.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<HostType> HostTypes { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<CredentialType> CredentialTypes { get; set; }
        public DbSet<Credential> Credentials { get; set; }


    }
}