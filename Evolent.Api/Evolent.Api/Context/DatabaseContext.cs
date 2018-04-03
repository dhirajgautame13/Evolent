using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Evolent.Api.Models;

namespace Evolent.Api.Context
{
    public class DatabaseContext : DbContext  
    {
        public DatabaseContext() : base("DefaultConnection") { }
        public DbSet<Contact> Contacts { get; set; }
      
    }
}