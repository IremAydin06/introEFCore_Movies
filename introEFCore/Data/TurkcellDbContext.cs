using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using introEFCore.Models;

namespace introEFCore.Data
{
    //Veri tabanına erişip orda işlemler yapacak class.
   public class TurkcellDbContext : DbContext
    {
        public TurkcellDbContext()
        {

        }

        public TurkcellDbContext(DbContextOptions<TurkcellDbContext> options) : base(options)
        {

        }

        //DbContext benim verilerime nasıl erişecek?
        public DbSet<Director> Directors{ get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Artist> Artists { get; set; }

        //polymorphism : https://www.turkayurkmez.com/nesne-yonelimli-programlama-5-polymorphism/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>()
                        .HasMany(x => x.Movies)      //Bir yönetmenin bir çok filmi vardır.
                        .WithOne(q => q.Director)   //Buradaki her filmin de sadece bir yönetmeni vardır.
                        .HasForeignKey(w => w.DirectorId);

            modelBuilder.Entity<Genre>()
                        .HasMany(e => e.Movies)
                        .WithOne(r => r.Genre)
                        .HasForeignKey(t => t.GenreId);

            //PK kolonlarını belirttik.
            modelBuilder.Entity<MovieArtist>()
                        .HasKey(ma => new { ma.MovieId, ma.ArtistId });         //İki kolondan oluşan bir primary key'i var. 


            modelBuilder.Entity<MovieArtist>()
                        .HasOne(m => m.Movie)
                        .WithMany(v => v.Artists)
                        .HasForeignKey(c => c.MovieId);

            modelBuilder.Entity<MovieArtist>()
                        .HasOne(v => v.Artist)
                        .WithMany(b => b.Movies)
                        .HasForeignKey(n => n.ArtistId);



            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  //Veritabanının bağlantı adresini yazacağız.
        {
            if (!optionsBuilder.IsConfigured)   //Web'de(.Net Core) olduğu zaman bunu yazmak zorunda değiliz. 
            {
                //Microsoft SQL Server'a veritabanını nereye oluşturacağını söyledik.
                optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLOCALDB; Database = LadiesOfTurkcell; Integrated Security = yes");
            }
        }

    }
}
