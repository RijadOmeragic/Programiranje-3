
using DLWMS.WinForms.IspitIB180084;
using System.Data.Entity;

namespace DLWMS.WinForms.DB
{

    //DLWMSContext
    public class KonekcijaNaBazu : DbContext
    {
        public KonekcijaNaBazu() : base("DLWMSPutanja")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable("Studenti");                      
        }       
        public DbSet<Student> Studenti { get; set; }

        public DbSet<PredmetIB180084> Predmeti { get; set; }

        public DbSet<StudentPredmetIB180084>  StudentiPredmeti{ get; set; }

        public DbSet<SpolIB180084> Spolovi { get; set; }

        public DbSet<StudentPorukaIB180084> StudentiPoruke { get; set; }



    }
}