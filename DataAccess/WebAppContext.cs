using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class WebAppContext : DbContext
    {
        public WebAppContext (DbContextOptions<WebAppContext> options)  // Constructor that takes DbContextOptions
            : base(options) // Pass options to the base DbContext class
        {

        }
        public DbSet<User> Users { get; set; } = default!;

        public DbSet<Models.User> User { get; set; } = default!;
    }
}
