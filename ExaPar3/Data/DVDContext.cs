using DVDCollection.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DVDCollection.Data {

    public class DVDContext: IdentityDbContext<User> {

        public DVDContext (DbContextOptions<DVDContext> options)
        : base (options)
        {

        }
        public DbSet<Actor> Actors {get; set;}
        public DbSet<FilmCertificate> FilmCertificates {get; set;}
        public DbSet<FilmGenre> FilmGenres {get; set;}
        public DbSet<FilmsActorRol> FilmsActorRols {get; set;}
        public DbSet<FilmTitle> FilmTitles {get; set;}
        public DbSet<FilmTitlesProducer> FilmTitlesProducers {get; set;}
        public DbSet<Producer> Producers {get; set;}
        public DbSet<RoleType> RoleTypes {get; set;}

        //API fluida
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Actor>().ToTable("Actor");
            modelBuilder.Entity<FilmCertificate>().ToTable("FilmCertificate");
            modelBuilder.Entity<FilmGenre>().ToTable("FilmGenre");
            modelBuilder.Entity<FilmsActorRol>().ToTable("FilmsActorRol");
            modelBuilder.Entity<FilmTitle>().ToTable("FilmTitle");
            modelBuilder.Entity<FilmTitlesProducer>().ToTable("FilmTitlesProducer");
            modelBuilder.Entity<Producer>().ToTable("Producer");
            modelBuilder.Entity<RoleType>().ToTable("RoleType");

            modelBuilder.Entity<FilmTitle>().Property<int>("CertificateID");
            modelBuilder.Entity<FilmTitle>().Property<int>("GenreID");



            modelBuilder.Entity<FilmsActorRol>().HasKey(c => new {c.FilmTitleID, c.ActorID,c.RoleTypeID});

            modelBuilder.Entity<FilmTitlesProducer>().HasKey(c => new {c.ProducerID, c.FilmTitleID});

            modelBuilder.Entity<FilmTitle>()
            .HasOne(p => p.FilmCertificate)
            .WithMany(b => b.FilmTitles)
            .HasForeignKey("CertificateID");

            modelBuilder.Entity<FilmTitle>()
            .HasOne(p => p.FilmGenre)
            .WithMany(b => b.FilmTitles)
            .HasForeignKey("GenreID");

        }

    }


}