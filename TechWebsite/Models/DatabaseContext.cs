using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechWebsite.Models
{
    public class DatabaseContext:DbContext
    {
            public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
            {

            }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<RoleAccount> RoleAccounts { get; set; }
    }
}
