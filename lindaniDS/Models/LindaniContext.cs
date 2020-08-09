using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace lindaniDS.Models
{

        public class LindaniContext : DbContext
    {

            public LindaniContext() : base("LindaniDB")
            {
                Database.SetInitializer<LindaniContext>(new CreateDatabaseIfNotExists<LindaniContext>());
            }

            public DbSet<VehicleHire> VehicleHires { get; set; }
            public DbSet<VehicleModel> VehicleModels { get; set; }
            public DbSet<BookingPackages> BookingPackages { get; set; }
    


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }

            public static LindaniContext Create()
            {
                return new LindaniContext();
            }

        public System.Data.Entity.DbSet<lindaniDS.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<lindaniDS.Models.Address> Addresses { get; set; }     

        public System.Data.Entity.DbSet<lindaniDS.ViewModels.HireViewModels> HireViewModels { get; set; }

       // public System.Data.Entity.DbSet<lindaniDS.Models.Payment> Payments { get; set; }

        public System.Data.Entity.DbSet<lindaniDS.Models.Learners> Learners { get; set; }

        public System.Data.Entity.DbSet<lindaniDS.Models.Licence> Licences { get; set; }

        public System.Data.Entity.DbSet<lindaniDS.Models.Payment> Payments { get; set; }
    }


    
}