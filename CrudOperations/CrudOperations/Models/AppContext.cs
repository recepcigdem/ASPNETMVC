using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrudOperations.Models
{
    public class AppContext:DbContext
    {
        public AppContext()
        :base("name=AppContext")
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}