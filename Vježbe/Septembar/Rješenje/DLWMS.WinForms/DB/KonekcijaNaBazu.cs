
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

        public DbSet<PredmetiIB180084> Predmeti { get; set; }

        public DbSet<StudentiPredmetiIB180084> StudentiPredmeti { get; set; }



    }
}