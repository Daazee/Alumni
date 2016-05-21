using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Alumni.Model;
namespace Alumni.DAL
{
 public   class AlumniContext : DbContext
    {
        public DbSet<AlumnusRegistration> AlumnusRegistrations { get; set; }
        public DbSet<AlumnusPicture> AlumnusPictures { get; set; }
    }
}
